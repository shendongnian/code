    public class ChangingPropagator
    {
        string[] listenedProperties = new string[0];
        Action<string> changesNotifyer = null;
        BindableObject propagationRootObject = null;
        List<KeyValuePair<string, object>> propagationProperties = new List<KeyValuePair<string, object>>();
        public ChangingPropagator(BindableObject bindableObject, Action<string> onPropertyChangedMethod, params string[] propertyToListenTo)
        {
            changesNotifyer = onPropertyChangedMethod;
            propagationRootObject = bindableObject;
            listenedProperties = propertyToListenTo ?? listenedProperties;
            
			// ToDo: Add some consistency checks
        }
        public void AddPropertyToListenTo(params string[] propertyName)
        {
            listenedProperties = listenedProperties.Union(propertyName).ToArray();
        }
		// I need handle it here too 'cause when I use the child `Ghost` property coming from XAML binding, it didn't hit the `set` method
        public T GetValue<T>(BindableProperty property)
        {
            var value = propagationRootObject?.GetValue(property);
            if (value != null)
            {
                INotifyPropertyChanged bindableSubObject = (value as INotifyPropertyChanged);
                if (bindableSubObject != null)
                {
                    bindableSubObject.PropertyChanged -= PropagatorListener;
                    bindableSubObject.PropertyChanged += PropagatorListener;
                    if (!propagationProperties.Any(a => a.Key == property.PropertyName))
                        propagationProperties.Add(new KeyValuePair<string, object>(property.PropertyName, value));
                }
            }
            return (T)value;
        }
        public void SetValue<T>(BindableProperty property, ref T value)
        {
            var oldValue = propagationRootObject?.GetValue(property);
            if (oldValue != null)
            {
                INotifyPropertyChanged bindableSubObject = (value as INotifyPropertyChanged);
                if (bindableSubObject != null)
                    bindableSubObject.PropertyChanged -= PropagatorListener;
            }
            if (value != null)
            {
                INotifyPropertyChanged bindableSubObject = (value as INotifyPropertyChanged);
                if (bindableSubObject != null)
                {
                    bindableSubObject.PropertyChanged += PropagatorListener;
                    propagationProperties.RemoveAll(p => p.Key == property.PropertyName);
                    propagationProperties.Add(new KeyValuePair<string, object>(property.PropertyName, value));
                }
            }
            propagationRootObject.SetValue(property, value);
        }
        private void PropagatorListener(object sender, PropertyChangedEventArgs e)
        {
            if (listenedProperties?.Contains(e.PropertyName) ?? true)
                PropagationThrower(sender);
        }
        private void PropagationThrower(object sender)
        {
            if (propagationProperties.Any(p => p.Value == sender))
            {
                var prop = propagationProperties.FirstOrDefault(p => p.Value == sender);
                changesNotifyer?.Invoke(prop.Key);
            }
        }
    }
