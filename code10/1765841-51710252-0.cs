    public class SensitiveDataDestructuringPolicy : IDestructuringPolicy
        {
            public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory, out LogEventPropertyValue result)
            {
                var props = value.GetType().GetTypeInfo().DeclaredProperties;
                var logEventProperties = new List<LogEventProperty>();
    
                foreach (var propertyInfo in props)
                {
                    switch (propertyInfo.Name.ToLower())
                    {
                        case "cardnumber":
                        case "password":
                            logEventProperties.Add(new LogEventProperty(propertyInfo.Name,propertyValueFactory.CreatePropertyValue("***")));
                            break;
                        default:
                            logEventProperties.Add(new LogEventProperty(propertyInfo.Name, propertyValueFactory.CreatePropertyValue(propertyInfo.GetValue(value))));
                            break;
                    }
                    
                }
                result = new StructureValue(logEventProperties);
                return true;
            }
        }
