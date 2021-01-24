    Word.Table table = Globals.MyAddIn.Application.ActiveDocument.Tables.Add(currentRange, 8, 3, ref missing, ref missing);
    range = table.Cell(1, 3).Range;
    // The text here starts as "\r\a"; if you turn on paragraph marks you will see an icon in each table cell; this must be that character
    range.Text = "SomeText" + Environment.NewLine;
    // Now the text is now "SomeText\r\r\a" (NewLine is "\r\n" and I think "\n" gets converted to "\r")
    // Note that Word will put \r or \a back if you omit them, since you're in a table cell
    range.MoveStartUntil(Environment.NewLine, Word.WdConstants.wdForward);
    // Now it's "\r\r\a"
    range.MoveStart(Word.WdUnits.wdCharacter, 1);
    // "\r\a"
    range.MoveEnd(Word.WdUnits.wdCharacter, -1);
    // finally the text is null (because it's a 0-length range), and in the needed location
    Word.ContentControl cc = range.ContentControls.Add();
    cc.Tag = "someTag";
