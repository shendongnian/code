    var outPutList = data.Replace("\r", string.Empty).Replace("\n", string.Empty).Split(",").Aggregate(new StringBuilder(""), (x, y) =>
    {
        if (double.TryParse(y, out double parsedValue))
            x.Append(" " + y.Trim());
        else
            x.AppendLine(y);
        return x;
    });
      richTextBox1.Text = outPutList.ToString(); 
