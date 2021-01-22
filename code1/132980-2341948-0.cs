    Word.Application oWord = default(Word.Application);
    Word.Document oDoc = default(Word.Document);
   
    oWord = Interaction.CreateObject("Word.Application");
    oWord.Visible = false;
   
    oDoc = oWord.Documents.Add(Directory + "\\MyDocument.dot");
   
    oDoc.Bookmarks("MyBookmark").Range.Text = strBookmark;
   
    oDoc.PrintOut();
    oDoc.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
    oDoc = null;
    oWord.Application.Quit();
    oWord = null;
