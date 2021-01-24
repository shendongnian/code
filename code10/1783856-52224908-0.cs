     if (bindingContext.ModelType == typeof(string))
     {
          // Already have a string. No further conversion required but handle ConvertEmptyStringToNull.
          if (bindingContext.ModelMetadata.ConvertEmptyStringToNull && string.IsNullOrWhiteSpace(value))
          {
               model = null;
          }
          else
          {
               model = value;
          }
     }
