    string[] LinesArray = this.richTextBox1.Lines;
    this.richTextBox1.Clear();
    for (int line = 0; line < LinesArray.Length; line++)
    {
    if (!LinesArray[line].Contains("< Test Text To Remove >"))
    {
    this.richTextBox1.AppendText(LinesArray[line] + Environment.NewLine);
    }
    }
