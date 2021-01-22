    public static T ToEnum<T>(this string input, T defaultValue)
        {
          var enumType = typeof (T);
          if (!enumType.IsEnum)
          {
            throw new ArgumentException(enumType + " is not an enumeration.");
          }
    
          // abort if no value given
          if (string.IsNullOrEmpty(input))
          {
            return defaultValue;
          }
    
          // see if the text is valid for this enumeration (case sensitive)
          var names = Enum.GetNames(enumType);
    
          if (Array.IndexOf(names, input) != -1)
          {
            // case insensitive...
            return (T) Enum.Parse(enumType, input, true);
          }
    
          // do partial matching...
          var match = names.Where(name => name.StartsWith(input, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
          if(match != null)
          {
            return (T) Enum.Parse(enumType, match);
          }
    
          // didn't find one
          return defaultValue;
        }
