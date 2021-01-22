    // Download content from a very, very simple "Hello World" web page.
    string download = new WebClient().DownloadString("http://black.ea.com/");
    
    Document document = new Document(PageSize.A4, 80, 50, 30, 65);
    try {
        using (FileStream fs = new FileStream("TestOutput.pdf", FileMode.Create)) {
            PdfWriter.GetInstance(document, fs);
            using (StringReader stringReader = new StringReader(download)) {
                ArrayList parsedList = HTMLWorker.ParseToList(stringReader, null);
                document.Open();
                foreach (object item in parsedList) {
                    document.Add((IElement)item);
                }
                document.Close();
            }
        }
    
    } catch (Exception exc) {
        Console.Error.WriteLine(exc.Message);
    }
  
