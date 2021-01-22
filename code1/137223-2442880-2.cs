    /// <summary>
    /// Aspect that, when applied to a class, registers to receive notifications when any
    /// child properties fire NotifyPropertyChanged.  This requires that the class
    /// implements a method OnChildPropertyChanged(Object sender, PropertyChangedEventArgs e). 
    /// </summary>
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Class,
        Inheritance = MulticastInheritance.Strict)]
    public class OnChildPropertyChangedAttribute : InstanceLevelAspect
    {
        [ImportMember("OnChildPropertyChanged", IsRequired = true)]
        public PropertyChangedEventHandler OnChildPropertyChangedMethod;
        private IEnumerable<PropertyInfo> SelectProperties(Type type)
        {
            const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public;
            return from property in type.GetProperties(bindingFlags)
                   where property.CanWrite && typeof(INotifyPropertyChanged).IsAssignableFrom(property.PropertyType)
                   select property;
        }
        /// <summary>
        /// Method intercepting any call to a property setter.
        /// </summary>
        /// <param name="args">Aspect arguments.</param>
        [OnLocationSetValueAdvice, MethodPointcut("SelectProperties")]
        public void OnPropertySet(LocationInterceptionArgs args)
        {
            if (args.Value == args.GetCurrentValue()) return;
            var current = args.GetCurrentValue() as INotifyPropertyChanged;
            if (current != null)
            {
                current.PropertyChanged -= OnChildPropertyChangedMethod;
            }
            args.ProceedSetValue();
            var newValue = args.Value as INotifyPropertyChanged;
            if (newValue != null)
            {
                newValue.PropertyChanged += OnChildPropertyChangedMethod;
            }
        }
    }
