      public static string RemoveEmptyLines(string value) {
        using (StringReader reader = new StringReader(yourstring)) {
          StringBuilder builder = new StringBuilder();
          string line;
          while ((line = reader.ReadLine()) != null) {
            if (line.Trim().Length > 0)
              builder.AppendLine(line);
          }
          return builder.ToString();
        }
      }
