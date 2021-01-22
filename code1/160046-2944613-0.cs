    using Microsoft.Office.Interop.Word;
    public string Test(string path)
    {
        Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
        object file = path;
        object nullobj = System.Reflection.Missing.Value;
        Document doc = wordApp.Documents.Open(ref file, ref nullobj, ref nullobj,
                                               ref nullobj, ref nullobj, ref nullobj,
                                               ref nullobj, ref nullobj, ref nullobj,
                                               ref nullobj, ref nullobj, ref nullobj);
        doc.ActiveWindow.Selection.WholeStory();
        doc.ActiveWindow.Selection.Copy();
        IDataObject data = Clipboard.GetDataObject();
        string result = data.GetData(DataFormats.Text).ToString();
        doc.Close();
        return result;
    }
