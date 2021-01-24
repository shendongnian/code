    var sb = new StringBuilder();
    while (i <= 10)
    {
        sb.Append(m)
          .Append(" * ")
          .Append(i)
          .Append(" = ")
          .AppendLine(m * i); // AppendLine will append the line break for you after the value
        i++;
    }
    textBox1.Text = sb.ToString()
    
