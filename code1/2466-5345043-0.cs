    [WebMethod]
        public object InvokeMethod(string methodName, Dictionary<string, object> methodArguments)
        {
            try
            {
                string lowerMethodName = '_' + methodName.ToLowerInvariant();
                List<object> tempParams = new List<object>();
                foreach (MethodInfo methodInfo in serviceMethods.Where(methodInfo => methodInfo.Name.ToLowerInvariant() == lowerMethodName))
                {
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    if (parameters.Length != methodArguments.Count()) continue;
                    else foreach (ParameterInfo parameter in parameters)
                        {
                            object argument = null;
                            if (methodArguments.TryGetValue(parameter.Name, out argument))
                            {
                                if (parameter.ParameterType.IsValueType)
                                {
                                    System.ComponentModel.TypeConverter tc = System.ComponentModel.TypeDescriptor.GetConverter(parameter.ParameterType);
                                    argument = tc.ConvertFrom(argument);
    
                                }
                                tempParams.Insert(parameter.Position, argument);
    
                            }
                            else goto ContinueLoop;
                        }
    
                    foreach (object attribute in methodInfo.GetCustomAttributes(true))
                    {
                        if (attribute is YourAttributeClass)
                        {
                            RequiresPermissionAttribute attrib = attribute as YourAttributeClass;
                            YourAttributeClass.YourMethod();//Mine throws an ex
                        }
                    }
    
                    return methodInfo.Invoke(this, tempParams.ToArray());
                ContinueLoop:
                    continue;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }
