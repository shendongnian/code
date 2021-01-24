    string result = string.Empty;
    foreach (string line in textBox2.Text.Split(Environment.NewLine.ToCharArray()))
    {
        result += line.Split(':')[0] + Environment.NewLine;
    }
