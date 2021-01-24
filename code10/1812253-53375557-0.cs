    public void AddLog(string log)
    {
        Run run = new Run(log);
        Paragraph paragraph = new Paragraph(run);
        paragraph.Background = new SolidColorBrush(Colors.Gray);
        var numberOfBlocks = logTextBox.Document.Blocks.Count;
        const int MaxNumberOfBlocks = 100;
        if (numberOfBlocks > MaxNumberOfBlocks)
        {
            logTextBox.Document.Blocks.Remove(logTextBox.Document.Blocks.FirstBlock);
        }
        logTextBox.Document.Blocks.Add(paragraph);
        logTextBox.Document.PagePadding = new Thickness(0); //<--
        logTextBox.ScrollToEnd();
    }
