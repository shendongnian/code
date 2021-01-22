    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Reflection;
    
    namespace YourNamespace
    {
      public struct ConversionResult
      {
         public Boolean Success;
         public object ConvertedValue;
      }
      public static class Reflector
      {
        private static BindingFlags DefaultBindings = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic;
        #region Public Methods
        /// <summary>
        /// Execute the "codeToExecute" string on the "source" object
        /// </summary>
        /// <param name="source">Object the code should be executed against</param>
        /// <param name="codeToExecute">Code that should be executed ex. 'Person.Age'</param>
        /// <returns>The result of execute codeToExecute on source</returns>
        public static object GetValue(object source, String codeToExecute)
        {
          ReflectorResult reflectorResult = GetReflectorResult(source, codeToExecute, true, false);
          if (reflectorResult != null)
          {
            return reflectorResult.Value;
          }
          return null;
        }
    
        /// <summary>
        /// Sets the "source" object to the "value" specified in "codeToExecute"
        /// </summary>
        /// <param name="source">Object the code should be executed against</param>
        /// <param name="codeToExecute">Code that should be executed ex. 'Person.Age'</param>
        /// <param name="value">Value to set the source+codeToExecute to.</param>
        public static Boolean SetValue(object source, String codeToExecute, object value)
        {
          return SetValue(source, codeToExecute, value, false);
        }
    
        /// <summary>
        /// Sets the "source" object to the "value" specified in "codeToExecute"
        /// </summary>
        /// <param name="source">Object the code should be executed against</param>
        /// <param name="codeToExecute">Code that should be executed ex. 'Person.Age'</param>
        /// <param name="value">Value to set the source+codeToExecute to.</param>
        /// <param name="createIfNotExists">Creates items it cannot find</param>
        public static Boolean SetValue(object source, String codeToExecute, object value, Boolean createIfNotExists)
        {
          Boolean executed = true;
    
          ReflectorResult reflectorResult = GetReflectorResult(source, codeToExecute, false, createIfNotExists);
          if (reflectorResult != null)
          {
            TypeConverter typeConverter = null;
            PropertyInfo propertyInfo = reflectorResult.MemberInfo as PropertyInfo;
            if (propertyInfo != null)
            {
              if (propertyInfo.CanWrite)
              {
                typeConverter = GetTypeConverter(propertyInfo);
    
                ConversionResult conversionResult = ConvertValue(value, propertyInfo.PropertyType, typeConverter);
                if (conversionResult.Success)
                {
                  propertyInfo.SetValue(reflectorResult.PreviousValue, conversionResult.ConvertedValue, reflectorResult.MemberInfoParameters);
                }
                else
                {
                  executed = false;
                  PentaLogger.LogVerbose("Invalid value: " + value);
                }
              }
            }
            else
            {
              FieldInfo fieldInfo = reflectorResult.MemberInfo as FieldInfo;
              if (fieldInfo != null)
              {
                typeConverter = GetTypeConverter(fieldInfo);
                ConversionResult conversionResult = ConvertValue(value, fieldInfo.FieldType, typeConverter);
                if (conversionResult.Success)
                {
                  fieldInfo.SetValue(reflectorResult.PreviousValue, conversionResult.ConvertedValue);
                }
                else
                {
                  executed = false;
                  PentaLogger.LogVerbose("Invalid value: " + value);
                }
              }
              else
              {
                // both property and field are invalid
                executed = false;
              }
            }
          }
          else
          {
            executed = false;
          }
    
          return executed;
        }
    
        /// <summary>
        /// Sets the "source" object to the "value" specified in "codeToExecute"
        /// </summary>
        /// <param name="source">Object the code should be executed against</param>
        /// <param name="codeToExecute">Code that should be executed ex. 'Person.Age'</param>
        /// <param name="value">Value to set the source+codeToExecute to.</param>
        public static void RunDynamicCode(object source, String codeToExecute)
        {
          GetReflectorResult(source, codeToExecute, true, false);
        }
    
        /// <summary>
        /// Executes the method on the "source" object with the passed parameters
        /// </summary>
        /// <param name="source">Object the code should be executed against</param>
        /// <param name="methodName">Method to call</param>
        /// <param name="parameters">Method Parameters</param>
        public static object ExecuteMethod(object source, String methodName, object[] parameters)
        {
          if (parameters == null)
          {
            parameters = new object[0];
          }
    
          MethodInfo[] methodInfos = GetMethods(source, methodName);
    
          foreach (MethodInfo methodInfo in methodInfos)
          {
            object[] convertedParameters = GetParameters(methodInfo, parameters);
            if (convertedParameters != null)
            {
              return methodInfo.Invoke(source, convertedParameters);
            }
          }
          return null;
        }
    
        /// <summary>
        /// Executes the method on the "source" object with the passed parameters
        /// </summary>
        /// <param name="source">Object the code should be executed against</param>
        /// <param name="methodName">Method to call</param>
        /// <param name="parameter">Method Parameter</param>
        public static object ExecuteMethod(object source, String methodName, object parameter)
        {
          return ExecuteMethod(source, methodName, new object[] { parameter });
        }
    
        /// <summary>
        /// Executes the method on the "source" object with no parameters
        /// </summary>
        /// <param name="source">Object the code should be executed against</param>
        /// <param name="methodName">Method to call</param>
        public static object ExecuteMethod(object source, String methodName)
        {
          return ExecuteMethod(source, methodName, null);
        }
    
        /// <summary>
        /// Copies all public properties and fields from source to target
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void CopyObject(object source, object target)
        {
          if (source != null && target != null)
          {
            Type targetType = target.GetType();
            Type sourceType = source.GetType();
    
            PropertyInfo[] properties = sourceType.GetProperties(DefaultBindings);
            foreach (PropertyInfo sourceProperty in properties)
            {
              PropertyInfo targetProperty = targetType.GetProperty(sourceProperty.Name, sourceProperty.PropertyType);
              if (targetProperty != null && targetProperty.CanRead && targetProperty.CanWrite)
              {
                object value = sourceProperty.GetValue(source, null);
                targetProperty.SetValue(target, value, null);
              }
            }
    
            FieldInfo[] fields = sourceType.GetFields(DefaultBindings);
            foreach (FieldInfo sourceField in fields)
            {
              FieldInfo targetField = targetType.GetField(sourceField.Name);
              if (targetField != null && targetField.IsPublic)
              {
                object value = sourceField.GetValue(source);
                targetField.SetValue(target, value);
              }
            }
          }
        }
    
        /// <summary>
        /// Convert the object to the correct type
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="type">Type to convert to</param>
        /// <returns>Converted value</returns>
        public static ConversionResult ConvertValue(object value, Type type, TypeConverter typeConverter)
        {
          ConversionResult conversionResult = new ConversionResult();
          conversionResult.Success = false;
          if (value != null && type != null)
          {
            Type objectType = value.GetType();
            if (objectType == type)
            {
              conversionResult.Success = true;
              conversionResult.ConvertedValue = value;
            }
            else
            {
              // If there is an explicit type converter use it
              if (typeConverter != null && typeConverter.CanConvertFrom(objectType))
              {
                try
                {
                  conversionResult.ConvertedValue = typeConverter.ConvertFrom(value);
                  conversionResult.Success = true;
                }
                catch (FormatException) { }
                catch (Exception e)
                {
                  if (!(e.InnerException is FormatException))
                  {
                    throw;
                  }
                }
              }
              else
              {
                try
                {
                  conversionResult.ConvertedValue = Convert.ChangeType(value, type, CultureInfo.CurrentCulture);
                  conversionResult.Success = true;
                }
                catch (InvalidCastException) { }
              }
            }
          }
          return conversionResult;
        }
    
        public static Boolean CanCreateObect(String classPath, Assembly assembly, params object[] parameters)
        {
          Boolean canCreate = false;
          Type type = Type.GetType(classPath);
          if (type == null)
          {
            String pathWithAssembly = classPath + ", " + assembly.FullName;
            type = Type.GetType(pathWithAssembly);
          }
    
          if (type != null)
          {
            foreach (ConstructorInfo ci in type.GetConstructors())
            {
              if (ci.IsPublic)
              {
                ParameterInfo[] constructorParameters = ci.GetParameters();
                if (constructorParameters.Length == parameters.Length)
                {
                  for(Int32 i=0; i<constructorParameters.Length; i++)
                  {                
                    object parameter = parameters[i];
                    if(parameter == null)
                    {
                      continue;
                    }
    
                    ParameterInfo pi = constructorParameters[i];
                    if (!pi.ParameterType.IsAssignableFrom(parameter.GetType()))
                    {
                      break;
                    }
                  }
                  canCreate = true;
                  break;
                }
              }  
            }       
          }
          return canCreate;
        }
    
        public static object CreateObject(String classPath, Assembly assembly, params object[] parameters)
        {
          Type type = Type.GetType(classPath);
          if (type == null)
          {
            String pathWithAssembly = classPath + ", " + assembly.FullName;
            type = Type.GetType(pathWithAssembly);
          }
    
          if (type == null)
          {
            return null;
          }
          return Activator.CreateInstance(type, parameters);
        }
        #endregion
    
        #region Private Methods
        private static ReflectorResult GetReflectorResult(object source, String codeToExecute, bool getLastValue, bool createIfNotExists)
        {
          ReflectorResult result = new ReflectorResult(source);
    
          try
          {
            // Split the code into usable fragments
            String[] codeFragments = SplitCodeArray(codeToExecute);
            for (Int32 i = 0; i < codeFragments.Length; i++)
            {
              // if the value is null we cannot go any deeper so don't waste your time
              if (result.Value == null)
              {
                return result;
              }
    
              String codeFragment = codeFragments[i];
              result.PreviousValue = result.Value;
    
              if (codeFragment.Contains("]"))
              {
                ProcessArray(result, codeFragment, createIfNotExists);
              }
              else if (codeFragment.Contains(")"))
              {
                ProcessMethod(result, codeFragment);
              }
              else
              {
                // For set properties we do not need the last value
                bool retrieveValue = getLastValue;
                if (!retrieveValue)
                {
                  // If this is not the last one in the array, get it anyway
                  retrieveValue = i + 1 != codeFragments.Length;
                }
                ProcessProperty(result, codeFragment, retrieveValue);
              }
            }
          }
          catch (InvalidCodeFragmentException ex)
          {
            PentaLogger.LogVerbose("Invalid Property: '" + codeToExecute + "' Invalid Fragment: '" + ex.Message + "'");
          }
    
          return result;
        }
    
        private static String[] SplitCodeArray(String codeToExecute)
        {
          List<String> items = new List<String>();
    
          Int32 parenAndbracketCount = 0;
          String buffer = "";
          foreach (Char c in codeToExecute.ToCharArray())
          {
            if (c == '.')
            {
              if (buffer.Length > 0)
              {
                items.Add(buffer);
                buffer = "";
              }
              continue;
            }
            else if (c == '[')
            {
              parenAndbracketCount++;
              if (buffer.Length > 0)
              {
                items.Add(buffer);
              }
              buffer = c.ToString();
            }
            else if (c == ']' || c == ')')
            {
              parenAndbracketCount--;
              buffer += c;
              if (buffer.Length > 0)
              {
                items.Add(buffer);
                buffer = "";
              }
            }
            else if (Char.IsWhiteSpace(c) || Char.IsControl(c))
            {
              if (parenAndbracketCount == 0)
              {
                // Skip it
                continue;
              }
              else
              {
                buffer += c;
              }
            }
            else if (c == '(')
            {
              parenAndbracketCount++;
              buffer += c;
            }
            else
            {
              buffer += c;
            }
          }
          if (buffer.Length > 0)
          {
            items.Add(buffer);
          }
          return items.ToArray();
        }
    
        private static object[] GetParameters(String codeFragment, MemberInfo memberInfo)
        {
          String parameters = SplitParametersFromMethod(codeFragment);
          if (String.IsNullOrEmpty(parameters))
            return new object[0];
    
          object[] parameterArray = parameters.Split(',');
          return GetParameters(memberInfo, parameterArray);
        }
    
        private static object[] GetParameters(MemberInfo memberInfo, object[] parameterArray)
        {
          ParameterInfo[] parameterInfo = null;
          TypeConverter typeConverter = null;
    
          PropertyInfo propertyInfo = memberInfo as PropertyInfo;
          if (propertyInfo != null)
          {
            parameterInfo = propertyInfo.GetIndexParameters();
            typeConverter = GetTypeConverter(parameterInfo[0]);
          }
          else
          {
            MethodInfo methodInfo = memberInfo as MethodInfo;
            if (methodInfo != null)
            {
              parameterInfo = methodInfo.GetParameters();
            }
          }
    
          if (parameterInfo == null)
          {
            return null;
          }
    
          object[] returnParameters = new object[parameterInfo.Length];
          for (Int32 i = 0; i < parameterArray.Length; i++)
          {
            ConversionResult converstionResult = ConvertValue(parameterArray[i], parameterInfo[i].ParameterType, typeConverter);
            if (converstionResult.Success)
            {
              returnParameters[i] = converstionResult.ConvertedValue;
            }
            else
            {
              return null;
            }
          }
          return returnParameters;
        }
    
        private static TypeConverter GetTypeConverter(MemberInfo memberInfo, Type targetType)
        {
          object[] typeConverters = memberInfo.GetCustomAttributes(typeof(TypeConverterAttribute), true);
          if (typeConverters.Length > 0)
          {
            TypeConverterAttribute typeConverterAttribute = (TypeConverterAttribute)typeConverters[0];
            Type typeFromName = Type.GetType(typeConverterAttribute.ConverterTypeName);
            if ((typeFromName != null) && typeof(TypeConverter).IsAssignableFrom(typeFromName))
            {
              return (TypeConverter)Activator.CreateInstance(typeFromName);
            }
          }
          return TypeDescriptor.GetConverter(targetType);
        }
    
        private static TypeConverter GetTypeConverter(PropertyInfo propertyInfo)
        {
          return GetTypeConverter(propertyInfo, propertyInfo.PropertyType);
        }
    
        private static TypeConverter GetTypeConverter(FieldInfo fieldInfo)
        {
          return GetTypeConverter(fieldInfo, fieldInfo.FieldType);
        }
    
        private static TypeConverter GetTypeConverter(ParameterInfo parameterInfo)
        {
          return GetTypeConverter(parameterInfo.Member, parameterInfo.ParameterType);
        }
    
        private static ArrayDefinition GetArrayDefinition(object value, String codeToExecute)
        {
          // All IList classes have an Item property except for System.Array.
          List<MemberInfo> retrieveMemberInfos = new List<MemberInfo>();
          foreach (PropertyInfo propertyInfo in value.GetType().GetProperties(DefaultBindings))
          {
            if (propertyInfo.Name == "Item")
            {
              retrieveMemberInfos.Add(propertyInfo);
            }
          }
    
          if (retrieveMemberInfos.Count == 0)
          {
            // We didn't find any Item properties so this is probably an Array. Use the GetValue method
            foreach (MethodInfo methodInfo in value.GetType().GetMethods(DefaultBindings))
            {
              if (methodInfo.Name == "GetValue")
              {
                retrieveMemberInfos.Add(methodInfo);
              }
            }
          }
    
          // Some members have overloaded this[] methods. Find the correct method.
          foreach (MemberInfo memberInfo in retrieveMemberInfos)
          {
            object[] parameters = GetParameters(codeToExecute, memberInfo);
            if (parameters != null)
            {
              ArrayDefinition arrayDefinition = new ArrayDefinition();
              arrayDefinition.Parameters = parameters;
              arrayDefinition.RetrieveMemberInfo = memberInfo;
              return arrayDefinition;
            }
          }
          return null;
        }
    
        private static void ProcessArray(ReflectorResult result, String codeFragment, Boolean createIfNotExists)
        {
          Int32 failCount = 0;
          ArrayDefinition arrayDefinition = GetArrayDefinition(result.Value, codeFragment);
          if (arrayDefinition != null)
          {
            // If this is anything but System.Array we need to call a Property
            PropertyInfo propertyInfo = arrayDefinition.RetrieveMemberInfo as PropertyInfo;
            if (propertyInfo != null)
            {
            SetPropertyInfoValue:
              try
              {
                object value = propertyInfo.GetValue(result.Value, arrayDefinition.Parameters);
                result.SetResult(value, propertyInfo, arrayDefinition.Parameters);
              }
              catch (TargetInvocationException ex)
              {
                failCount++;
                if (ex.InnerException is ArgumentOutOfRangeException && failCount == 1 && createIfNotExists)
                {
                  if (CreateArrayItem(result, arrayDefinition))
                  {
                    goto SetPropertyInfoValue;
                  }
                }
    
                // Tried to fix it but failed. Blow up
                result.Clear();
                throw new InvalidCodeFragmentException(codeFragment);
              }
            }
            else
            {
              // System.Array has a Method to call
              MethodInfo methodInfo = arrayDefinition.RetrieveMemberInfo as MethodInfo;
              if (methodInfo != null)
              {
                try
                {
                  // We can't support dynamically creating array items
                  object value = methodInfo.Invoke(result.Value, arrayDefinition.Parameters);
                  result.SetResult(value, methodInfo, arrayDefinition.Parameters);
                }
                catch (TargetInvocationException)
                {
                  result.Clear();
                  throw new InvalidCodeFragmentException(codeFragment);
                }
              }
            }
          }
          else
          {
            result.Clear();
            throw new InvalidCodeFragmentException(codeFragment);
          }
        }
    
        private static Boolean CreateArrayItem(ReflectorResult result, ArrayDefinition arrayDefinition)
        {
          Type resultType = result.Value.GetType();
          Type containedType = null;
          if (resultType.IsArray)
          {
            containedType = resultType.GetElementType();
          }
          else
          {
            containedType = resultType.GetGenericArguments()[0];
          }
    
          object newInstance = Activator.CreateInstance(containedType);
          if (!resultType.IsArray)
          {
            MethodInfo[] methods = GetMethods(result.Value, "Insert");
            foreach (MethodInfo methodInfo in methods)
            {
              object[] temp = new object[arrayDefinition.Parameters.Length + 1];
              arrayDefinition.Parameters.CopyTo(temp, 0);
              temp[arrayDefinition.Parameters.Length] = newInstance;
    
              object[] parameters = GetParameters(methodInfo, temp);
              if (parameters != null)
              {
                methodInfo.Invoke(result.Value, parameters);
                return true;
              }
            }
          }
          return false;
        }
    
        private static void ProcessProperty(ReflectorResult result, String codeFragment, bool retrieveValue)
        {
          // This is just a regular property
          PropertyInfo propertyInfo = result.Value.GetType().GetProperty(codeFragment, DefaultBindings);
          if (propertyInfo != null)
          {
            object value = result.Value;
            if (retrieveValue)
            {
              value = propertyInfo.GetValue(result.Value, null);
              result.SetResult(value, propertyInfo, null);
            }
            result.SetResult(value, propertyInfo, null);
          }
          else
          {
            // Maybe it is a field
            FieldInfo fieldInfo = result.Value.GetType().GetField(codeFragment, DefaultBindings);
    
            if (fieldInfo != null)
            {
              object value = result.Value;
              if (retrieveValue)
              {
                value = fieldInfo.GetValue(result.Value);
              }
              result.SetResult(value, fieldInfo, null);
            }
            else
            {
              // This item is missing, log it and set the value to null
              result.Clear();
              throw new InvalidCodeFragmentException(codeFragment);
            }
          }
        }
    
        private static void ProcessMethod(ReflectorResult result, String codeFragment)
        {
          // This is just a regular property
          String methodName = codeFragment.Substring(0, codeFragment.IndexOf('('));
          MethodInfo[] methodInfos = GetMethods(result.Value, methodName);
    
          foreach (MethodInfo methodInfo in methodInfos)
          {
            object[] parameters = GetParameters(codeFragment, methodInfo);
            if (parameters != null)
            {
              object value = methodInfo.Invoke(result.Value, parameters);
              result.SetResult(value, null, null);
              break;
            }
          }
        }
    
        private static String SplitParametersFromMethod(String codeFragment)
        {
          char startCharacter = '[';
          char endCharacter = ']';
    
          if (codeFragment.EndsWith(")", StringComparison.CurrentCulture))
          {
            // This is a function
            startCharacter = '(';
            endCharacter = ')';
          }
    
          Int32 startParam = codeFragment.IndexOf(startCharacter) + 1;
          if (startParam < 1)
            return null;
    
          Int32 endParam = codeFragment.IndexOf(endCharacter);
          if (endParam < 0)
            return null;
    
          return codeFragment.Substring(startParam, endParam - startParam).Trim();
        }
    
        private static MethodInfo[] GetMethods(object value, String methodName)
        {
          if (String.IsNullOrEmpty(methodName))
          {
            throw new ArgumentNullException("methodName");
          }
    
          if (value == null)
          {
            return new MethodInfo[0];
          }
    
          List<MethodInfo> methodInfos = new List<MethodInfo>();
          foreach (MethodInfo methodInfo in value.GetType().GetMethods(DefaultBindings))
          {
            if (methodInfo.Name == methodName)
            {
              methodInfos.Add(methodInfo);
            }
          }
          return methodInfos.ToArray();
        }
        #endregion
    
        #region Helper Classes
        private class ArrayDefinition
        {
          public MemberInfo RetrieveMemberInfo { get; set; }
    
          public object[] Parameters { get; set; }
        }
    
        private class ReflectorResult
        {
          public ReflectorResult(object startValue)
          {
            SetResult(startValue, null, null);
          }
          public MemberInfo MemberInfo { get; private set; }
          public object[] MemberInfoParameters { get; private set; }
          public object PreviousValue { get; set; }
          public object Value { get; private set; }
    
          public void SetResult(object value, MemberInfo memberInfo, object[] memberInfoParameters)
          {
            Value = value;
            MemberInfo = memberInfo;
            MemberInfoParameters = memberInfoParameters;
          }
    
          public void Clear()
          {
            MemberInfo = null;
            Value = null;
            PreviousValue = null;
          }
        }
    
        [Serializable]
        [SuppressMessage("Microsoft.Design", "CA1064:ExceptionsShouldBePublic")]
        [SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors")]
        private class InvalidCodeFragmentException : Exception
        {
          public InvalidCodeFragmentException(String invalidFragment)
            : base(invalidFragment)
          {
    
          }
        }
        #endregion
      }
    }
