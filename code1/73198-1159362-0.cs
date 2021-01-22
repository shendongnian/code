    Microsoft.Office.Interop.Word.Document doc = 
        axFramerControl1.ActiveDocument as Microsoft.Office.Interop.Word.Document;
    doc.Content.Select();
    doc.Content.Copy();
    this.richTextBox1.Paste();
