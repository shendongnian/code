    string result = string.Empty;
    foreach (string line in textBox2.Text.Split('\n'))
    {
        result += line.Split(':')[0] + Environment.NewLine;
    }
