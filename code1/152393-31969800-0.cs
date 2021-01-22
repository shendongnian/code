    string s1 = textBox1.Text;
    Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
    Microsoft.Office.Interop.Word._Document doc = app.Documents.Add();
    doc.Words.First.InsertBefore(s1);
    Microsoft.Office.Interop.Word.ProofreadingErrors errors = doc.SpellingErrors;
    int errorCount = errors.Count;
    doc.CheckSpelling(Missing.Value, true, false);
    app.Quit(false);
    textBox3.Text = errorCount.ToString();
