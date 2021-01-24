    [ValueConversion(typeof(MyObject), typeof(string))]
    class MyObjectToComboBoxConverter : IValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            try {
                var theObject = (MyObject)value;
                var id = theObject.Id;
                return (((id != -1) ? id.ToString() : "default") + " : " + theObject.Description);
            } catch(InvalidCastException e) {
                return (string)value;
            }
        }
    
        public override object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
