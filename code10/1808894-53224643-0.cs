    RichTextBox rtb = new RichTextBox();
    string rtf = File.ReadAllText("file.rtf");
    using (MemoryStream stream = new MemoryStream(Encoding.Default.GetBytes(rtf)))
        rtb.Selection.Load(stream, DataFormats.Rtf);
    string text = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text;
    string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    foreach(string line in lines)
    {
        //...
    }
