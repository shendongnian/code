            get { return (Boolean)GetValue(IsCheckedProperty); }
            set { 
                if (value != IsChecked) SetValue(IsCheckedProperty, value);
                if (IsChecked == true)
                    ButtonImage.Source = EnabledChecked;
                else
                    ButtonImage.Source = EnabledUnchecked;
            }
        }
