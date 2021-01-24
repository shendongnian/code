    class IngredientsListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = value as IEnumerable<string>;
    
            if (list == null) 
                return String.Empty;
    
            var output = String.Join(", ", list.Take(3));
            
            if (list.Count > 3)
                output += "...";
            
            return output;
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
