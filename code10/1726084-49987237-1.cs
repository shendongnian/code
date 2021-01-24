    string Document = "[SomeDocumentText]";
    List<string> Pages = new List<string>();
    TextFormatFlags flags = TextFormatFlags.Top | TextFormatFlags.Left |
                            TextFormatFlags.WordBreak | TextFormatFlags.NoPadding | 
                            TextFormatFlags.TextBoxControl;
    Size textSize = TextRenderer.MeasureText(Document, richTextBox1.Font, richTextBox1.ClientSize, flags);
    int NumberOfPages = textSize.Height / richTextBox1.ClientSize.Height;
    if (textSize.Height > richTextBox1.Height)
    {
        richTextBox1.Text = Document;
        richTextBox1.Update();
        //Number of shown lines
        int FirstCharOfLastShownLine = richTextBox1.GetCharIndexFromPosition(new Point(0, richTextBox1.ClientSize.Height));
        int ShownLines = richTextBox1.GetLineFromCharIndex(FirstCharOfLastShownLine);
        int TotalLines = richTextBox1.GetLineFromCharIndex(richTextBox1.Text.Length - 1);
        for (int p = 0; p < NumberOfPages; p++)
        {
            int FirstLineOfPage = (p * ShownLines);
            int FirstCharOfPage = richTextBox1.GetFirstCharIndexFromLine(FirstLineOfPage);
            int FirstLineOfNextPage = (p + 1) * ShownLines;
            FirstLineOfNextPage = (FirstLineOfNextPage > TotalLines) ? TotalLines : FirstLineOfNextPage;
            int LastCharOfPage = (FirstLineOfNextPage < TotalLines)
                               ? richTextBox1.GetFirstCharIndexFromLine(FirstLineOfNextPage) - 1
                               : richTextBox1.Text.Length;
            Pages.Add(richTextBox1.Text.Substring(FirstCharOfPage, LastCharOfPage - FirstCharOfPage));
        }
    }
    else
    {
        Pages.Add(Document);
    }
    richTextBox1.Text = Pages.First();
 
