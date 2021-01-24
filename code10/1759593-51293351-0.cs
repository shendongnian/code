        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {           
            double parsed=0;
            if (!double.TryParse(out parsed))
             return parsed;
             return (parsed) / 100.00;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
               double parsed=0;
            if (!double.TryParse(out parsed))
             return parsed;
            return System.Convert.ToInt32(parsed) * 100;
        }      
    }
