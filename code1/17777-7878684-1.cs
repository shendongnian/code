    public class PropertyInfoWrapper
    {
        private readonly object _parent;
        private readonly PropertyInfo _property;
        public PropertyInfoWrapper(object parent, string propertyToChange)
        {
            var type = parent.GetType();
            var privateProperties= type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            var property = type.GetProperty(propertyToChange) ??
                           privateProperties.FirstOrDefault(p => UnQualifiedNameFor(p) == propertyName);
            if (property == null)
                throw new Exception(string.Format("cant find property |{0}|", propertyToChange));
            _parent = parent;
            _property = property;
        }
        private static string UnQualifiedNameFor(PropertyInfo p)
        {
            return p.Name.Split('.').Last();
        }
        public object Value
        {
            get { return _property.GetValue(_parent, null); }
            set { _property.SetValue(_parent, value, null); }
        }
    }
