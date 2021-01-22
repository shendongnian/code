    TextRange test = new TextRange(range.End, range.End.Paragraph.ContentEnd);
    bool IsAtEnd = test.IsEmpty || String.IsNullOrEmpty(test.Text) || test.Text == "\r\n";
    // Now we know whether the Caret is still in the middle of the text or not
    // This part corrects the Caret glitch! :)
    if (!IsAtEnd)
        this.CaretPosition = range.End;
    else
        this.CaretPosition = range.Start.GetNextContextPosition(LogicalDirection.Forward);
