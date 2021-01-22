    Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
    object nullobj = System.Reflection.Missing.Value;
    object file = openFileDialog1.FileName;
    Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(
      ref file, ref nullobj, ref nullobj,
      ref nullobj, ref nullobj, ref nullobj,
      ref nullobj, ref nullobj, ref nullobj,
      ref nullobj, ref nullobj, ref nullobj,
      ref nullobj, ref nullobj, ref nullobj);
    doc.ActiveWindow.Selection.WholeStory();
    doc.ActiveWindow.Selection.Copy();
    IDataObject data = Clipboard.GetDataObject();
    
    // get number of pages
    Microsoft.Office.Interop.Word.WdStatistic stat = Microsoft.Office.Interop.Word.WdStatistic.wdStatisticPages;
    int pages = doc.ComputeStatistics(stat, Type.Missing);
    
    string text = data.GetData(DataFormats.Text).ToString();
    textBox2.Text = text;
    doc.Close(ref nullobj, ref nullobj, ref nullobj);
    app.Quit(ref nullobj, ref nullobj, ref nullobj);
