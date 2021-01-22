      public class PropertyValueAccessConverter : IMultiValueConverter
      {
        object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
          var target = values[0];
          var fieldList = values[1] as IEnumerable<KeyValuePair<string,string>>;
          return
            from pair in fieldList
            select new PropertyAccessor
            {
              Name = pair.Name,
              Target = target,
              Value = target.GetType().GetProperty(target.Value),
            };
        }
    
        object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
          throw new InvalidOperationException();
        }
    
        public class PropertyAccessor
        {
          public string Name
          public object Target;
          public PropertyInfo Property;
        
          public object Value
          {
            get { return Property.GetValue(Target, null); }
            set { Property.SetValue(Target, value, null); }
          }
        }
    
        public static PropertyValueAccessConverter Instance = new PropertyValueAccessConverter();
      }
