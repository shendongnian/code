    /// <summary>
    /// Help to find metadata from expression instead of string declaration to improve reflection reliability.
    /// </summary>
    static public class Metadata
    {
        /// <summary>
        /// Identify method from method call expression.
        /// </summary>
        /// <typeparam name="T">Type of return.</typeparam>
        /// <param name="expression">Method call expression.</param>
        /// <returns>Method.</returns>
        static public MethodInfo Method<T>(Expression<Func<T>> expression)
        {
            return (expression.Body as MethodCallExpression).Method;
        }
    }
    /// <summary>
    /// Help to find metadata from expression instead of string declaration to improve reflection reliability.
    /// </summary>
    /// <typeparam name="T">Type to reflect.</typeparam>
    static public class Metadata<T>
    {
        /// <summary>
        /// Cache typeof(T) to avoid lock.
        /// </summary>
        static public readonly Type Type = typeof(T);
        /// <summary>
        /// Only used as token in metadata expression.
        /// </summary>
        static public T Value { get { throw new InvalidOperationException(); } }
    }
    /// <summary>
    /// Used to clone instance of any class.
    /// </summary>
    static public class Cloner
    {
        /// <summary>
        /// Define cloner implementation of a specific type.
        /// </summary>
        /// <typeparam name="T">Type to clone.</typeparam>
        static private class Implementation<T>
            where T : class
        {
            /// <summary>
            /// Delegate create at runtime to clone.
            /// </summary>
            static public readonly Action<T, T> Clone = Cloner.Implementation<T>.Compile();
            /// <summary>
            /// Way to emit delegate without static constructor to avoid performance issue.
            /// </summary>
            /// <returns>Delegate used to clone.</returns>
            static public Action<T, T> Compile()
            {
                //Define source and destination parameter used in expression.
                var _source = Expression.Parameter(Metadata<T>.Type);
                var _destination = Expression.Parameter(Metadata<T>.Type);
                //Clone method maybe need more than one statement.
                var _body = new List<Expression>();
                //Clone all fields of entire hierarchy.
                for (var _type = Metadata<T>.Type; _type != null; _type = _type.BaseType)
                {
                    //Foreach declared fields in current type.
                    foreach (var _field in _type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly))
                    {
                        //Assign destination field using source field.
                        _body.Add(Expression.Assign(Expression.Field(_destination, _field), Expression.Field(_source, _field)));
                    }
                }
                //Compile expression to provide clone method.
                return Expression.Lambda<Action<T, T>>(Expression.Block(_body), _source, _destination).Compile();
            }
        }
        /// <summary>
        /// Keep instance of generic definition of clone method to improve performance in reflection call case.
        /// </summary>
        static private readonly MethodInfo Method = Metadata.Method(() => Cloner.Clone(Metadata<object>.Value)).GetGenericMethodDefinition();
        static public T Clone<T>(T instance)
            where T : class
        {
            //Nothing to clone.
            if (instance == null) { return null; } 
            //Identify instace type.
            var _type = instance.GetType(); 
            //if T is an interface, instance type might be a value type and it is not needed to clone value type.
            if (_type.IsValueType) { return instance; } 
            //Instance type match with generic argument.
            if (_type == Metadata<T>.Type) 
            {
                //Instaitate clone without executing a constructor.
                var _clone = FormatterServices.GetUninitializedObject(_type) as T;
                //Call delegate emitted once by linq expreesion to clone fields. 
                Cloner.Implementation<T>.Clone(instance, _clone); 
                //Return clone.
                return _clone;
            }
            //Reflection call case when T is not target Type (performance overhead).
            return Cloner.Method.MakeGenericMethod(_type).Invoke(null, new object[] { instance }) as T;
        }
    }
