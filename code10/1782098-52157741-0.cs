         public abstract class ObservableBase : INotifyPropertyChanged
            {
                public void Set<TValue>(ref TValue field, TValue newValue, [CallerMemberName] string propertyName = "")
                {
                    if (!EqualityComparer<TValue>.Default.Equals(field, default(TValue)) && field.Equals(newValue)) return;
                    field = newValue;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }
        
                public event PropertyChangedEventHandler PropertyChanged;
        
                public void NotifyPropertyChanged(string propertyName)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        
        
            public abstract class ViewModelBase : ObservableBase
            {
                public bool IsInDesignMode
                    => (bool)DesignerProperties.IsInDesignModeProperty
                        .GetMetadata(typeof(DependencyObject))
                        .DefaultValue;
            }
    
