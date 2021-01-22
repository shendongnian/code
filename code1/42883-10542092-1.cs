    public class PropertyChangedNotifierBase<T> : INotifyPropertyChanged
    {
        readonly Dictionary<string, object> _properties = new Dictionary<string, object>();
        protected U GetValue<U>(Expression<Func<T, U>> property)
        {
            var propertyName = GetPropertyName(property);
            return GetValue<U>(propertyName);
        }
        private U GetValue<U>(string propertyName)
        {
            object value;
            if (!_properties.TryGetValue(propertyName, out value))
            {
                return default(U);
            }
            return (U)value;
        }
        protected void SetPropertyValue<U>(Expression<Func<T, U>> property, U value)
        {
            var propertyName = GetPropertyName(property);
            var oldValue = GetValue<U>(propertyName);
            if (Object.ReferenceEquals(oldValue, value))
            {
                return;
            }
            _properties[propertyName] = value;
            RaisePropertyChangedEvent(propertyName);
        }
        protected void RaisePropertyChangedEvent<U>(Expression<Func<T, U>> property)
        {
            var name = GetPropertyName(property);
            RaisePropertyChangedEvent(name);
        }
        protected void RaisePropertyChangedEvent(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private static string GetPropertyName<U>(Expression<Func<T, U>> property)
        {
            if (property == null)
            {
                throw new NullReferenceException("property");
            }
            var lambda = property as LambdaExpression;
            var memberAssignment = (MemberExpression) lambda.Body;
            return memberAssignment.Member.Name;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
