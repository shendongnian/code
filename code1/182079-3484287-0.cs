    // Two lines of text.
    textEditorControl.Text = 
        "First\r\n" +
        "Second\r\n";
    // Start of selection - columns and lines are zero based.
    int startCol = 0;
    int startLine = 1;
    TextLocation start = new TextLocation(startCol, startLine);
    // End of selection.
    int endCol = 6;
    int endLine = 1;
    TextLocation end = new TextLocation(endCol, endLine);
    // Select the second line.
    textEditorControl.ActiveTextAreaControl.SelectionManager.SetSelection(start, end);
    // Move cursor to end of selection.
    textEditorControl.ActiveTextAreaControl.Caret.Position = end;
