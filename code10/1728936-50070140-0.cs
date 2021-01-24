    string name = "test";
    string[] files = Directory.GetFiles("C:\\Users")
                              .Where(s => s.Contains(name))
                              .ToArray();
    RichTextBox richTextBox = new RichTextBox();
    foreach (string file in files)
    {
        string content = File.ReadAllText(file);
        richTextBox.AppendText(content);
    }
