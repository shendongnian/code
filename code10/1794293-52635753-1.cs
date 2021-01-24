    public class DictionaryToStringConverter : IValueConverter {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        // cast object to dictionary
        Dictionary<string, Thumbnail> thumbnails = value as Dictionary<string, Thumbnail>;
        // cast parameter to dictionary key 
        String key = parameter as string;
        // retrieve value from dictionary
        Uri uri = thumbnails[key].Url;
        // returning string because label's text property is string
        return uri.AbsoluteUri;
      }
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException("Not implemented");
      }
    }
