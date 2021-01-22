    public static class DateTimeSecondCatcher
    {
        PropertyInfo dateTimePropertyInfo = sender.GetType().GetProperty(e.PropertyName);
            if ((dateTimePropertyInfo != null) && (dateTimePropertyInfo.PropertyType == typeof(DateTime)))
            {
                DateTime dteValue = (DateTime)dateTimePropertyInfo.GetValue(sender, null);
                if (dteValue.Millisecond > 0)
                {
                    dateTimePropertyInfo.SetValue(sender, new DateTime(dteValue.Year,dteValue.Month,dteValue.Day, dteValue.Hour,dteValue.Minute,dteValue.Second,0,dteValue.Kind), null);
                }
            }
    }
    // This code goes in the partial class constructor
    this.PropertyChanged += new PropertyChangedEventHandler(DateTimeSecondCatcher.OnPropertyChanged);
