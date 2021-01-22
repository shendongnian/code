    Word.Application wordApp = new Word.Application();
    wordApp.Visible = false;
    
    PrintDialog pDialog = new PrintDialog();
    if (pDialog.ShowDialog() == DialogResult.OK)
    {
      Word.Document doc = wordApp.Documents.Add(@"c:\temp.docx");
      wordApp.ActivePrinter = pDialog.PrinterSettings.PrinterName;
      wordApp.ActiveDocument.PrintOut(); //this will also work: doc.PrintOut();
      doc.Close(SaveChanges: false);
      doc = null;
    }
    
    // <EDIT to include Jason's suggestion>
    ((Word._Application)wordApp).Quit(SaveChanges: false); 
    // </EDIT>
    // Original: wordApp.Quit(SaveChanges: false);
    wordApp = null;
