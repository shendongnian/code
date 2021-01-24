      public static partial class StringExtensions {
        public static int IndexOfQuoted(this string value,
                                        char toFind,
                                        int startPosition = 0,
                                        char quotation = '"') {
          if (string.IsNullOrEmpty(value))
            return -1;
    
          bool inQuotation = false;
    
          for (int i = 0; i < value.Length; ++i)
            if (inQuotation)
              inQuotation = value[i] != quotation;
            else if (value[i] == toFind && i >= startPosition)
              return i;
            else
              inQuotation = value[i] == quotation;
    
          return -1;
        }
      }
