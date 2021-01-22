    public static class DateTimeSecondCatcher
    {
        public static void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.GetType() == typeof(DateTime))
            {
                PropertyInfo dateTimePropertyInfo = sender.GetType().GetProperty(e.PropertyName);
                if (dateTimePropertyInfo != null)
                {
                    DateTime dteValue = (DateTime)dateTimePropertyInfo.GetValue(sender, null);
                    dateTimePropertyInfo.SetValue(sender, new DateTime(dteValue.Year, dteValue.Month, dteValue.Day, dteValue.Hour, dteValue.Minute, 0), null);
                }
            }
        }
    }
    // This code goes in the partial class constructor
    this.PropertyChanged += new PropertyChangedEventHandler(DateTimeSecondCatcher.OnPropertyChanged);
