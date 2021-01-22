    public object Convert(object value, Type targetType,
                          object parameter, CultureInfo culture)
    {
        try
        {
            return new BitmapImage(new Uri((string)value));
        }
        catch 
        {
            return new BitmapImage();
        }
    }
    public object ConvertBack(object value, Type targetType,
                              object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
