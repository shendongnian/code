    Document document = new Document(PageSize.A4, 80, 50, 30, 65); 
    try  {
       using (FileStream fs = new FileStream("TestOutput.pdf", FileMode.Create)) {
          PdfWriter.GetInstance(document, fs);
          HtmlParser.Parse(document, "YourHtmlDocument.html");
       }
    } catch(Exception exc)  { 
       Console.Error.WriteLine(exc.Message); 
    } 
