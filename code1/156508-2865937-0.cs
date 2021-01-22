    string RemoveEmptyLines(this string text) {
        var builder = new StringBuilder();
    
        using (var reader = new StringReader(text)) {
            while (reader.Peek() != -1) {
                string line = reader.ReadLine();
                if (!string.IsNullOrEmpty(line))
                    builder.AppendLine(line);
            }
        }
    
        return builder.ToString();
    }
