    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    public static class DeepCopyByExpressionTrees
    {
        private static readonly Type ObjectType = typeof(Object);
        private static readonly Type DelegateType = typeof(Delegate);
        private static readonly Type ObjectDictionaryType = typeof(Dictionary<object,object>);
        private static readonly Type ThisType = typeof(DeepCopyByExpressionTrees);
        private static readonly Type CultureInfoType = typeof(CultureInfo);
        private static readonly Type StringType = typeof(String);
        private static readonly Type ArrayType = typeof(Array);
        private static readonly Type IntType = typeof(Int32);
        private static readonly Type BooleanType = typeof(Boolean);
        private static readonly Type DecimalType = typeof(Decimal);
        private static readonly MethodInfo MemberwiseCloneMethod = ObjectType.GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);
        private static readonly MethodInfo DeepCopyByExpressionTreeObjMethod = ThisType.GetMethod("DeepCopyByExpressionTreeObj", BindingFlags.Static | BindingFlags.NonPublic);
        private static readonly MethodInfo ArrayGetLengthMethod = ArrayType.GetMethod("GetLength", BindingFlags.Instance | BindingFlags.Public);
        private static readonly MethodInfo SetFieldByReflectionMethod = ThisType.GetMethod("SetFieldByReflection", BindingFlags.NonPublic | BindingFlags.Static);
        private static readonly object CompiledExpressionsLocker = new object();
        private static Dictionary<Type, Func<object, Dictionary<object, object>, object>> CompiledExpressionsDict =
            new Dictionary<Type, Func<object, Dictionary<object, object>, object>>();
        
        /// <summary>
        /// Creates a deep copy of an object.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="obj">Object to copy.</param>
        /// <param name="copiedReferencesDict">Dictionary of already copied objects.</param>
        /// <returns></returns>
        public static T DeepCopyByExpressionTree<T>(this T obj, Dictionary<object, object> copiedReferencesDict = null)
        {
            return (T)DeepCopyByExpressionTreeObj(obj, false, copiedReferencesDict ?? new Dictionary<object, object>());
        }
        
        private static object DeepCopyByExpressionTreeObj(object obj, bool forceDeepCopy, Dictionary<object, object> copiedReferencesDict)
        {
            if (obj == null)
            {
                return null;
            }
            var type = obj.GetType();
            if (!forceDeepCopy && !IsTypeToDeepCopy(type))
            {
                return obj;
            }
            if (IsDelegate(type))
            {
                return null;
            }
            object alreadyCopiedObject;
            if (copiedReferencesDict.TryGetValue(obj, out alreadyCopiedObject))
            {
                return alreadyCopiedObject;
            }
            if (type == ObjectType)
            {
                return new object();
            }
            var compiledCopier = GetOrCreateCompiledLambdaCopyFunction(type);
            object copy = compiledCopier(obj, copiedReferencesDict);
            
            return copy;
        }
        
        private static Func<object, Dictionary<object,object>, object> GetOrCreateCompiledLambdaCopyFunction(Type type)
        {
            Func<object, Dictionary<object, object>, object> compiledCopier;
            if (!CompiledExpressionsDict.TryGetValue(type, out compiledCopier))
            {
                lock (CompiledExpressionsLocker)
                {
                    if (!CompiledExpressionsDict.TryGetValue(type, out compiledCopier))
                    {
                        var uncompiledCopier = CreateDeepCopyExpressionForType(type);
                        compiledCopier = uncompiledCopier.Compile();
                        var copy = CompiledExpressionsDict.ToDictionary(a => a.Key, a => a.Value);
                        copy.Add(type, compiledCopier);
                        CompiledExpressionsDict = copy;
                    }
                }
            }
            return compiledCopier;
        }
        private static Expression<Func<object, Dictionary<object, object>, object>> CreateDeepCopyExpressionForType(Type type)
        {
            List<ParameterExpression> variables;
            List<Expression> expressions;
            ParameterExpression inputParameter;
            ParameterExpression inputDictionary;
            ParameterExpression outputVariable;
            LabelTarget endLabel;
            InitialExpressions(out variables, out expressions, out inputParameter, out inputDictionary, out outputVariable, out endLabel);
            var ifNullReturn = IfNullThenReturnExpression(inputParameter, endLabel);
            expressions.Add(ifNullReturn);
            var memberwiseClone = MemberwiseCloneInputToOutputExpression(inputParameter, outputVariable);
            expressions.Add(memberwiseClone);
            var storeReferencesToDictionary = StoreReferencesIntoDictionaryExpression(inputParameter, inputDictionary, outputVariable);
            expressions.Add(storeReferencesToDictionary);
            var fields = GetAllRelevantFields(type);
            foreach (var fieldInfo in fields)
            {
                var fieldCopy = FieldCopyExpression(type, fieldInfo, inputParameter, inputDictionary, outputVariable);
                expressions.Add(fieldCopy);
            }
            if (type.IsArray)
            {
                var elementType = type.GetElementType();
                if (IsTypeToDeepCopy(elementType))
                {
                    CreateArrayItemsCopyLoopExpression(
                        type,
                        inputParameter,
                        inputDictionary,
                        outputVariable,
                        ref variables,
                        ref expressions);
                }
            }
            var lambda = PutEverythingTogetherExpression(inputParameter, inputDictionary, outputVariable, endLabel, variables, expressions);
            return lambda;
        }
        private static FieldInfo[] GetAllRelevantFields(Type type, bool forceAllFields = false)
        {
            var fieldsList = new List<FieldInfo>();
            var typeCache = type;
            while (typeCache != null)
            {
                fieldsList.AddRange(
                    typeCache
                        .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                        .Where(field => forceAllFields || IsTypeToDeepCopy(field.FieldType)));
                typeCache = typeCache.BaseType;
            }
            return fieldsList.ToArray();
        }
        
        private static void InitialExpressions(
            out List<ParameterExpression> variables,
            out List<Expression> expressions,
            out ParameterExpression inputParameter,
            out ParameterExpression inputDictionary,
            out ParameterExpression outputVariable,
            out LabelTarget endLabel)
        {
            variables = new List<ParameterExpression>();
            expressions = new List<Expression>();
            inputParameter = Expression.Parameter(ObjectType);
            inputDictionary = Expression.Parameter(ObjectDictionaryType);
            outputVariable = Expression.Variable(ObjectType);
            variables.Add(outputVariable);
            endLabel = Expression.Label();
        }
        private static Expression<Func<object, Dictionary<object, object>, object>> PutEverythingTogetherExpression(
            ParameterExpression inputParameter,
            ParameterExpression inputDictionary,
            ParameterExpression outputVariable,
            LabelTarget endLabel,
            List<ParameterExpression> variables,
            List<Expression> expressions)
        {
            expressions.Add(Expression.Label(endLabel));
            expressions.Add(outputVariable);
            var finalBlock = Expression.Block(variables, expressions);
            var lambda = Expression.Lambda<Func<object, Dictionary<object, object>, object>>(finalBlock, inputParameter, inputDictionary);
            return lambda;
        }
        private static Expression StoreReferencesIntoDictionaryExpression(ParameterExpression inputParameter, ParameterExpression inputDictionary, ParameterExpression outputVariable)
        {
            //// Expression output:
            ////
            //// inputDictionary[(Object)input] = (Object)output;
            var storeReferencesExpression =
                Expression.Assign(
                    Expression.Property(
                        Expression.Convert(inputDictionary, ObjectDictionaryType),
                        ObjectDictionaryType.GetProperty("Item"),
                        Expression.Convert(inputParameter, ObjectType)),
                    Expression.Convert(outputVariable, ObjectType));
            return storeReferencesExpression;
        }
        private static Expression FieldCopyExpression(Type type, FieldInfo field, ParameterExpression inputParameter, ParameterExpression inputDictionary, ParameterExpression outputVariable)
        {
            //// Expression output:
            ////
            //// output.<field> = (<fieldType>)DeepCopyByExpressionTreeObj((Object)input.<field>);
            ////
            //// OR
            ////
            //// output.<field> = input.<field>;
            if (!field.IsInitOnly)
            {
                var fieldFrom = Expression.Field(Expression.Convert(inputParameter, type), field);
                var fieldTo = Expression.Field(Expression.Convert(outputVariable, type), field);
                var fieldType = field.FieldType;
                if (IsTypeToDeepCopy(fieldType))
                {
                    var fieldCopyExpression =
                        Expression.Assign(
                            fieldTo,
                            Expression.Convert(
                                Expression.Call(
                                    DeepCopyByExpressionTreeObjMethod,
                                    Expression.Convert(fieldFrom, ObjectType),
                                    Expression.Constant(true, BooleanType),
                                    inputDictionary),
                                fieldType));
                    return fieldCopyExpression;
                }
                else
                {
                    var fieldCopyExpression =
                        Expression.Assign(
                            fieldTo,
                            fieldFrom);
                    return fieldCopyExpression;
                }
            }
            else
            {
                // This option must be implemented by Reflection because of the following:
                // https://visualstudio.uservoice.com/forums/121579-visual-studio-2015/suggestions/2727812-allow-expression-assign-to-set-readonly-struct-f
                var fieldCopyExpression =
                    Expression.Call(
                        SetFieldByReflectionMethod,
                        Expression.Constant(field),
                        inputParameter,
                        inputDictionary,
                        outputVariable
                        );
                return fieldCopyExpression;
            }
        }
        
        private static void CreateArrayItemsCopyLoopExpression(
            Type type,
            ParameterExpression inputParameter,
            ParameterExpression inputDictionary,
            ParameterExpression outputVariable,
            ref List<ParameterExpression> variables,
            ref List<Expression> expressions)
        {
            //// Expression output:
            ////
            //// int index1, index2, ..., indexn; 
            //// 
            //// int length1 = inputarray.GetLength(0); 
            //// index1 = 0; 
            //// while (true)
            //// {
            ////     if (index1 >= length1)
            ////     {
            ////         goto LOOPENDLABEL1;
            ////     }
            ////     int length2 = inputarray.GetLength(1); 
            ////     index2 = 0; 
            ////     while (true)
            ////     {
            ////         if (index2 >= length2)
            ////         {
            ////             goto LOOPENDLABEL2;
            ////         }
            ////         ...
            ////         ...
            ////         ...
            ////         int lengthn = inputarray.GetLength(n); 
            ////         indexn = 0; 
            ////         while (true)
            ////         {
            ////             if (indexn >= lengthn)
            ////             {
            ////                 goto LOOPENDLABELn;
            ////             }
            ////             outputarray[index1, index2, ..., indexn] 
            ////                 = (<elementType>)DeepCopyByExpressionTreeObj(
            ////                        (Object)inputarray[index1, index2, ..., indexn])
            ////             indexn++; 
            ////         }
            ////         LOOPENDLABELn:
            ////         ...
            ////         ...  
            ////         ...
            ////         index2++; 
            ////     }
            ////     LOOPENDLABEL2:
            ////     index1++; 
            //// }
            //// LOOPENDLABEL1:
            var rank = type.GetArrayRank();
            var indices = CreateIndices(rank);
            variables.AddRange(indices);
            var elementType = type.GetElementType();
            var assignExpression = ArrayFieldToArrayFieldAssignExpression(inputParameter, inputDictionary, outputVariable, elementType, type, indices);
            Expression forExpression = assignExpression;
            for (int dimension = 0; dimension < rank; dimension++)
            {
                var indexExp = indices[dimension];
                forExpression = LoopIntoLoopExpression(inputParameter, indexExp, forExpression, dimension);
            }
            expressions.Add(forExpression);
        }
        private static BlockExpression LoopIntoLoopExpression(
            ParameterExpression inputParameter,
            ParameterExpression indexExp,
            Expression loopToEncapsulate,
            int dimension)
        {
            //// Expression output:
            ////
            //// int length = inputarray.GetLength(dimension); 
            //// index = 0; 
            //// while (true)
            //// {
            ////     if (index >= length)
            ////     {
            ////         goto LOOPENDLABEL;
            ////     }
            ////     loopToEncapsulate;
            ////     index++; 
            //// }
            //// LOOPENDLABEL:
            var lengthExp = Expression.Variable(IntType);
            var loopEndLabel = Expression.Label();
            var newLoop =
                Expression.Loop(
                    Expression.Block(
                        new ParameterExpression[0],
                        Expression.IfThen(
                            Expression.GreaterThanOrEqual(indexExp, lengthExp),
                            Expression.Break(loopEndLabel)),
                        loopToEncapsulate,
                        Expression.PostIncrementAssign(indexExp)),
                    loopEndLabel);
            var lengthAssignment = GetLengthForDimensionExpression(lengthExp, inputParameter, dimension);
            var indexAssignment = Expression.Assign(indexExp, Expression.Constant(0));
            return Expression.Block(
                new[] { lengthExp },
                lengthAssignment,
                indexAssignment,
                newLoop);
        }
        private static List<ParameterExpression> CreateIndices(int rank)
        {
            //// Expression output:
            ////
            //// int index1, index2, ..., indexn; 
            var indices = new List<ParameterExpression>();
            for (int i = 0; i < rank; i++)
            {
                indices.Add(Expression.Variable(IntType));
            }
            return indices;
        }
        private static BinaryExpression ArrayFieldToArrayFieldAssignExpression(
            ParameterExpression inputParameter,
            ParameterExpression inputDictionary,
            ParameterExpression outputVariable,
            Type elementType,
            Type arrayType,
            List<ParameterExpression> indices)
        {
            //// Expression output:
            ////
            //// outputarray[i1, i2, ..., in] 
            ////     = (<elementType>)DeepCopyByExpressionTreeObj(
            ////            (Object)inputarray[i1, i2, ..., in]);
            var indexTo = Expression.ArrayAccess(Expression.Convert(outputVariable, arrayType), indices);
            var indexFrom = Expression.ArrayIndex(Expression.Convert(inputParameter, arrayType), indices);
            var copyIndexFrom =
                Expression.Convert(
                    Expression.Call(
                        DeepCopyByExpressionTreeObjMethod,
                        Expression.Convert(indexFrom, ObjectType),
                        Expression.Constant(true, BooleanType),
                        inputDictionary),
                    elementType);
            var assignExpression = Expression.Assign(indexTo, copyIndexFrom);
            return assignExpression;
        }
        private static BinaryExpression GetLengthForDimensionExpression(
            ParameterExpression lengthExp,
            ParameterExpression inputParameter,
            int i)
        {
            //// Expression output:
            ////
            //// length = ((Array)input).GetLength(i); 
            return Expression.Assign(
                lengthExp,
                Expression.Call(
                    Expression.Convert(inputParameter, ArrayType),
                    ArrayGetLengthMethod,
                    new[] { Expression.Constant(i) }));
        }
        private static BinaryExpression MemberwiseCloneInputToOutputExpression(
            ParameterExpression inputParameter,
            ParameterExpression outputVariable)
        {
            //// Expression output:
            ////
            //// var output = (Object)input.MemberwiseClone();
            return
                Expression.Assign(
                    outputVariable,
                    Expression.Convert(
                        Expression.Call(
                            inputParameter,
                            MemberwiseCloneMethod),
                        ObjectType));
        }
        private static ConditionalExpression IfNullThenReturnExpression(ParameterExpression inputParameter, LabelTarget endLabel)
        {
            //// Expression output:
            ////
            //// if (input == null)
            //// {
            ////     return null;
            //// }
            return
                Expression.IfThen(
                    Expression.Equal(
                        inputParameter,
                        Expression.Constant(null, ObjectType)),
                    Expression.Return(endLabel));
        }
        
        private static bool IsTypeToDeepCopy(Type type)
        {
            return (type.IsClass
                   || type.IsInterface)
                   && type != StringType
                   && type != DecimalType
                   && type != CultureInfoType;
        }
        
        private static bool IsDelegate(Type type)
        {
            return DelegateType.IsAssignableFrom(type);
        }
        // ReSharper disable once UnusedMember.Local
        private static void SetFieldByReflection(FieldInfo fieldInfo, object objFrom, Dictionary<object, object> copiedReferencesDict,  object objTo)
        {
            var value = fieldInfo.GetValue(objFrom);
            var fieldType = fieldInfo.FieldType;
            if (value != null && IsTypeToDeepCopy(fieldType))
            {
                var convertedValue = DeepCopyByExpressionTreeObj(value, true, copiedReferencesDict);
                fieldInfo.SetValue(objTo, convertedValue);
            }
            else
            {
                fieldInfo.SetValue(objTo, value);
            }
        }
    }
