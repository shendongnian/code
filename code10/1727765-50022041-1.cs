    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        int time = int.Parse(value.ToString());
        
        string trainStatus = TrainTimeStatus(System.Convert.ToInt32(value))
        value = TimeSpan.FromSeconds(time);
        if (string.IsNullOrWhiteSpace(value.ToString()) || ((TimeSpan)value).Equals(TimeSpan.MinValue))
            return "––:––";
        else
            return ((((TimeSpan)value) < TimeSpan.Zero) ? "-" : "") +
           ((TimeSpan)value).ToString(@"mm\:ss") + trainStatus;
    }
    public string TrainTimeStatus(int time)
    {
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
