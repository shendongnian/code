    Paragraph paragraph = new Paragraph();
    string[] lines = Value.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
    Run run = new Run(new Text(lines[0]));
    if (lines.Length > 1)
    {
      run.AppendChild(new Break());
      run.AppendChild(new Text(lines[1]));
    }
    paragraph.Append(run);
