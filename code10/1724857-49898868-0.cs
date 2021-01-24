    Microsoft.Office.Interop.Word.Application WordApp;
    Microsoft.Office.Interop.Word.Document WordDoc;
    // coding here
    WordDoc.Save();
    WordApp.NormalTemplate.Saved = true;
    WordDoc.Close(true);
    WordApp.Quit();
