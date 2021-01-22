    public class SomeConverter : IValueConverter
    {
        private ResourceDictionary _resourceDictionary;
        public ResourceDictionary ResourceDictionary
        {
            get { return _resourceDictionary; }
            set 
            {
                _resourceDictionary = value; 
            }
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //do you own thing using the _dict
            //var person = value as Person
            //if (person.Status == "Awesome")
            //    return _resourceDictionary["AwesomeBrush"]
            //else
            //    return _resourceDictionary["NotAwesomeBrush"];
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        
    }
