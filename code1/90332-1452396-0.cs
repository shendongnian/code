        public double AnimateValue {
        get { return (double)GetValue(AnimateValueProperty); }
        set {
                SetValue(AnimateValueProperty, value);
                OnPropertyChanged(new PropertyChangedEventArgs("AnimateValue"));
                OnPropertyChanged(new PropertyChangedEventArgs("GuiValue "));
            }
        }
    }
