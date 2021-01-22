    protected void SetProperty<T>(String propertyName, ref T property, T value)
    {
        if (!Object.Equals(property, value))
        {
            bool cancelled = OnPropertyChanging<T>(propertyName, property, value);
    
            if (cancelled)
            {
                Application.Current.Dispatcher.BeginInvoke(
                    new Action(() =>
                    {
                        OnPropertyChanged<T>(propertyName);
                    }),
                    DispatcherPriority.ContextIdle,
                    null
                );
    
                return;
            }
    
            T originalValue = property;
            property = value;
            OnPropertyChanged(propertyName, originalValue, property);
        }
    }
