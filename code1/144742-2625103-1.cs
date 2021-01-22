    public object Convert(object[] values, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
    {
        // TODO: Input type checks
        // TODO: Castings, find key in other table, return relevant field
        return (values[1] as IDictionary<String, String>)[values[0] as String];
    }
