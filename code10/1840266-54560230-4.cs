    abstract class ObservableObject : INotifyPropertyChanged
    {
        // We're using a ConcurrentDictionary<K,V> to ensure the thread safety.
        // The C# 7 tuples are lightweight and fast.
        private static readonly ConcurrentDictionary<(Type, string), string> dependencies =
            new ConcurrentDictionary<(Type, string), string>();
        // Here we store already processed types and also a flag
        // whether a type has at least one dependency
        private static readonly ConcurrentDictionary<Type, bool> registeredTypes = new ConcurrentDictionary<Type, bool>();
        protected ObservableObject()
        {
            Type thisType = GetType();
            if (registeredTypes.ContainsKey(thisType))
            {
                return;
            }
            var properties = thisType.GetProperties()
                .SelectMany(propInfo => propInfo.GetCustomAttributes<DependsOn>()
                    .SelectMany(attribute => attribute.Properties
                        .Select(propName => (SourceType: attribute.Type, SourceProperty: propName, TargetProperty: propInfo.Name))));
            bool atLeastOneDependency = false;
            foreach (var property in properties)
            {
                // If the type in the attribute was not set,
                // we assume that the property comes from this type.
                Type sourceType = property.SourceType ?? thisType;
                // The dictionary keys are the event source type
                // *and* the property name, combined into a tuple     
                dependencies[(sourceType, property.SourceProperty)] = property.TargetProperty;
                atLeastOneDependency = true;
            }
            registeredTypes[thisType] = atLeastOneDependency;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, e);
            if (registeredTypes[GetType()])
            {
                // Only check dependent properties if there is at least one dependency.
                // Need to call this for our own properties,
                // because there can be dependencies inside the class.
                RaisePropertyChangedForDependentProperties(this, e);
            }
        }
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }
            if (registeredTypes[GetType()])
            {
                if (field is INotifyPropertyChanged oldValue)
                {
                    // We need to remove the old subscription to avoid memory leaks.
                    oldValue.PropertyChanged -= RaisePropertyChangedForDependentProperties;
                }
                // If a type has some property dependencies,
                // we hook-up events to get informed about the changes in the child objects.
                if (value is INotifyPropertyChanged newValue)
                {
                    newValue.PropertyChanged += RaisePropertyChangedForDependentProperties;
                }
            }
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        private void RaisePropertyChangedForDependentProperties(object sender, PropertyChangedEventArgs e)
        {
            // We look whether there is a dependency for the pair
            // "Type.PropertyName" and raise the event for the dependent property.
            if (dependencies.TryGetValue((sender.GetType(), e.PropertyName), out var dependentProperty))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(dependentProperty));
            }
        }
    }
