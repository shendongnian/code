    class NullableDateTimeConverter : ValidationRule, IValueConverter
    {
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (value == null || value.ToString().Trim().Length == 0) return null;
        return new ValidationResult( 
            ConvertBack(value, typeof(DateTime?), null, cultureInfo) != DependencyProperty.UnsetValue,
            "Please enter a valid date, or leave this value blank");
    }
    #region IValueConverter Members
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null) return "";
        DateTime? dt = value as DateTime?;
        if (dt.HasValue)
        {
            return parameter == null ? dt.Value.ToString() : dt.Value.ToString(parameter.ToString());
        }
        return ""; 
    } 
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null || value.ToString().Trim().Length == 0) return null;
        string s = value.ToString();
        if (s.CompareTo("today") == 0) return DateTime.Today;
        if (s.CompareTo("now") == 0) return DateTime.Now;
        if (s.CompareTo("yesterday") == 0) return DateTime.Today.AddDays(-1);
        if (s.CompareTo("tomorrow") == 0) return DateTime.Today.AddDays(1);
        DateTime dt; 
        if (DateTime.TryParse(value.ToString(), out dt)) return dt; 
        return DependencyProperty.UnsetValue; 
    }  
    #endregion
