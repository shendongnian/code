    public class XmlAttributeOverrideGenerator<T>
    {
        private static XmlAttributeOverrides _overrides;
        private static Type[] _ignoreAttributes = new Type[] { typeof(DefaultValueAttribute) };
        static XmlAttributeOverrideGenerator()
        {
            _overrides = Generate();
        }
        
        public static XmlAttributeOverrides Get()
        {
            return _overrides;
        }
        private static XmlAttributeOverrides Generate()
        {
            var xmlAttributeOverrides = new XmlAttributeOverrides();
            Type targetType = typeof(T);
            foreach (var property in targetType.GetProperties())
            {
                XmlAttributes propertyAttributes = new XmlAttributes(new CustomAttribProvider(property, _ignoreAttributes));
                xmlAttributeOverrides.Add(targetType, property.Name, propertyAttributes);
            }
            return xmlAttributeOverrides;
        }
        public class CustomAttribProvider : ICustomAttributeProvider
        {
            private PropertyInfo _prop = null;
            private Type[] _ignoreTypes = null;            
            public CustomAttribProvider(PropertyInfo property, params Type[] ignoreTypes)
            {
                _ignoreTypes = ignoreTypes;
                _prop = property;
            }
            public object[] GetCustomAttributes(bool inherit)
            {
                var attribs = _prop.GetCustomAttributes(inherit);
                if (_ignoreTypes == null) return attribs;
                return attribs.Where(attrib => IsAllowedType(attrib)).ToArray();
            }
            private bool IsAllowedType(object attribute)
            {
                if (_ignoreTypes == null) return true;
                foreach (Type type in _ignoreTypes)
                    if (attribute.GetType() == type)
                        return false;
                return true;
            }
            public object[] GetCustomAttributes(Type attributeType, bool inherit)
            {
                throw new NotImplementedException();
            }
            public bool IsDefined(Type attributeType, bool inherit)
            {
                throw new NotImplementedException();
            }
        }
    }
