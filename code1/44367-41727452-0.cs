    using Word = Microsoft.Office.Interop.Word;
    var wordApp = new Word.Application();
    wordApp.Visible = true;
    wordApp.Documents.Add(@"C:\workingtemplate.dotx");
    //Open is for an existing document. 
    //Add is to use a template.
    //Get the range to be able to then collapse and have the correct insertion point
    var rng = wordApp.ActiveDocument.Range();
    rng.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
    rng.InsertBreak(Word.WdBreakType.wdPageBreak);
    rng.InsertFile(@"C:\temp.docx");
