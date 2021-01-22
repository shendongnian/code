    public class PropertyValue
    {
        private PropertyInfo propertyInfo;
        private object baseObject;
        public PropertyValue(PropertyInfo propertyInfo, object baseObject)
        {
            this.propertyInfo = propertyInfo;
            this.baseObject = baseObject;
        }
        public string Name { get { return propertyInfo.Name; } }
        public Type PropertyType { get { return propertyInfo.PropertyType; } }
        public object Value
        {
            get { return propertyInfo.GetValue(baseObject, null); }
            set { propertyInfo.SetValue(baseObject, value, null); }
        }
    }
