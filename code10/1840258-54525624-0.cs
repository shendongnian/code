    [Serializable]
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        // ... 
        // Code left out for brevity 
        // ...
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            return this.SetField<T>(ref field, value, false, propertyName);
        }
        protected bool SetField<T>(ref T field, T value, bool forceUpdate, [CallerMemberName] string propertyName = null)
        {
            bool valueChanged = !EqualityComparer<T>.Default.Equals(field, value);
            if (valueChanged || forceUpdate)
            {
                RemovePropertyEventHandler(field as ObservableObject);
                AddPropertyEventHandler(value as ObservableObject);
                field = value;
                this.OnPropertyChanged(propertyName);
            }
            return valueChanged;
        }
        protected void AddPropertyEventHandler(ObservableObject observable)
        {
            if (observable != null)
            {
                observable.PropertyChanged += ObservablePropertyChanged;
            }
        }
        protected void RemovePropertyEventHandler(ObservableObject observable)
        {
            if (observable != null)
            {
                observable.PropertyChanged -= ObservablePropertyChanged;
            }
        }
        private void ObservablePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.OnPropertyChanged($"{sender.GetType().Name}.{e.PropertyName}");
        }
    }
