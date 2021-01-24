    Range currentRange = Paragraphs[3].Range;
    Table table = Tables.Add(currentRange, 8, 3, ref missing, ref missing);
    Range range = table.Cell(1, 3).Range;
    // Starts as "\r\a"
    range.Text = "SomeText";
    // The text is now "SomeText\r\a"
    range.MoveEnd(WdUnits.wdCharacter, -1);
    // "SomeText"
    range.Bold = 1;
    range.InsertParagraphAfter();
    // "SomeText\r" (this puts the paragraph mark inside the current range which is kind of counter-intuitive)
    range.Collapse(WdCollapseDirection.wdCollapseEnd);
    // This is the new paragraph
    Interop.ContentControl cc = range.ContentControls.Add();
    cc.Tag = "someTag";
