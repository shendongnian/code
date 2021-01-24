    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var isError = value as bool? ?? false;
        if (isError)
        {
            if (App.SelectedTheme == ElementTheme.Light)
            {
                return Application.Current.Resources["MyBorderBrushMandatory"] as SolidColorBrush;
            }
            else
            {
                return Application.Current.Resources["MyBorderBrushMandatoryDark"] as SolidColorBrush;
            }
        }
        else
        {
            return null;
        }
    }
