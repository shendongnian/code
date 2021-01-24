    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        int time = System.Convert.ToInt32(value);
        if (time > 0)
        {
            return "Delayed";
        } 
        if (time < 0 )
        {
            return "In Advance";
        }
        if (time == 0)
        {
            return "On Time";
        }
        return ""; //Or Argument Exception, your call
    }
