    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Wordprocessing;
    
    namespace OXmlTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var wordDocument = WordprocessingDocument
                    .Create("c:\\deleteme\\testdoc.docx", WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
    
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());
                    Paragraph p = body.AppendChild(new Paragraph());                
                    Run r = p.AppendChild(new Run());
    
                    string theString = "This is an example project for testing purposes. \rThis is all sample data, none of this is real information. \r\rThis field allows for the entry of more information, a larger text field for example purposes";
    
                    foreach (string s in theString.Split(new char[] { '\r' }))
                    {
                        r.AppendChild(new Text(s));
                        r.AppendChild(new Break());
                    }
    
                    wordDocument.Save();
                }
            }
        }
    }
