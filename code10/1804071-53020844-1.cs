    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            double sumActualWidths = values.Sum(v => System.Convert.ToDouble(v));
            if (targetType == typeof(GridLength))
                return new GridLength(sumActualWidths);
            else
                return System.Convert.ChangeType(sumActualWidths, targetType);
        }
        catch (Exception ex)
        {
            Oops! Something went wrong.
            I better handle this exception in a meaningful way.
            return Binding.DoNothing;
        }
    }
