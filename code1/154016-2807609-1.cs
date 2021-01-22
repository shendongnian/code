    System.Text.StringBuilder content = new System.Text.StringBuilder();
    using (var reader = new StreamReader(fDialog.FileName.ToString()))
    {
        string line = reader.ReadLine();
        while (line != null)
        {
            var matchingExpression = Regex.Match(line, @"(X[-\d.]+)(Y[-\d.]+)(Z(?:\d*\.)?\d+)[^H]*G0H((?:\d*\.)?\d+)\w*");
            content.AppendFormat(
                System.Globalization.CultureInfo.InvariantCulture,
                "{0}{1}G54G0T{2}\n",
                matchingExpression.Groups[0].Value,
                matchingExpression.Groups[1].Value,
                Int32.Parse(matchingExpression.Groups[3].Value) + 1);
            content.AppendFormat(
                System.Globalization.CultureInfo.InvariantCulture,
                "G43{0}H{1}M08\n", 
                matchingExpression.Groups[2].Value, 
                matchingExpression.Groups[3].Value);
            line = reader.ReadLine();
        }
    }
