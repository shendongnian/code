    public class ParametersParser
    {
        public static IEnumerable<PropertyInfo> GetAllParameterProperties(Type parameterType)
        {
            foreach (var property in parameterType.GetProperties())
            {
                if (Attribute.IsDefined(property, typeof(SomeAttribute)))
                    yield return property;
                if (typeof(ParametersBase).IsAssignableFrom(property.PropertyType))
                {
                    foreach (var subProperty in GetAllParameterProperties(property.PropertyType))
                        yield return subProperty;
                }
            }
        }
    }
