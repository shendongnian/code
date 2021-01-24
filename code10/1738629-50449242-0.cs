    var file = //file path
    var sb = new StringBuilder();
    var lineNum = 1;
    var output = string.Empty;
    
    using (var reader = new StreamReader(file))
    {
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (lineNum % 3 == 0)
            {
                output += sb.ToString() + "\n";
                sb.Clear();
            }
            else
                sb.Append(line);
            lineNum++;
        }
    }
    
    richTextBox1.Text = output;
