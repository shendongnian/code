      public static string SeparateWords(string enumName)
      {
          var buffer = new StringBuilder();
          var wasLower = false;
          foreach (var c in enumName)
          {
              if (wasLower && char.IsUpper(c))
              {
                  buffer.Append(' ');
              }
              buffer.Append(c);
              wasLower = char.IsLower(c);
          }
          return buffer.ToString();
      }
      public static void DisplayMenu<T>() where T : struct //should be System.Enum if possible
      {
          var enumType = typeof(T);
          var names = Enum.GetNames(enumType);
          var values = Enum.GetValues(enumType) as int[];
          for (var i = 0; i < names.Length; ++i)
          {
              Console.WriteLine($"[{values[i]}] {SeparateWords(names[i])}");
          }
      }
