    Globals.ThisDocument.Paragraphs.First.Range.Select();
    var cc = Globals.ThisDocument.Controls.AddRichTextContentControl(Guid.NewGuid().ToString());
    var newRange = cc.Range;
    object count = 1;
    newRange.Move(Unit: Word.WdUnits.wdParagraph, Count: ref count);
    Globals.ThisDocument.Paragraphs.Add();
    newRange.Move(Unit: Word.WdUnits.wdParagraph, Count: ref count);
    var cc2 = Globals.ThisDocument.Controls.AddRichTextContentControl(newRange, Guid.NewGuid().ToString());
