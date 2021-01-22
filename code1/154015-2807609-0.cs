    StringBuilder content = new StringBuilder();
    using (var reader = new StreamReader(fDialog.FileName.ToString()))
    {
      string line = reader.ReadLine();
      while(line != null)
      {
        content.AppendLine(Regex.Replace(content, @"X[-\d.]+Y[-\d.]+", "$0G54G0"));
        var matchingExpression = Regex.Match(content, @"(Z(?:\d*\.)?\d+)[^H]*G0H((?:\d*\.)?\d+)\w*");
        content.AppendFormat(CultureInfo.InvariantCulture, "G43{0}{1}M08", matchingExpression.Groups[0].Value, Int32.Parse(matchingExpression.Groups[1].Value) + 1);
        line = reader.ReadLine();
      }
    }
