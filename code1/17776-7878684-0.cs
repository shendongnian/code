    public class PropertyInfoWrapper
    {
        private readonly object _parent;
        private readonly PropertyInfo _property;
        public PropertyInfoWrapper(object parent, string propertyToChange)
        {
            var type = parent.GetType();
            var allProperties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            var property = type.GetProperty(propertyToChange) ??
                           allProperties.Single(p => p.Name.EndsWith(propertyToChange));
            if (property == null)
                throw new Exception(string.Format("cant find property |{0}|", propertyToChange));
            _parent = parent;
            _property = property;
        }
        public object Value
        {
            get { return _property.GetValue(_parent, null); }
            set { _property.SetValue(_parent, value, null); }
        }
    }
