    public class DocumentWriter
    {
        public /*virtual*/ void CreateDocument()
        {
           CreatePage();
        }
    
        protected virtual void CreatePage()
        {
            System.Console.WriteLine("DocumentWriter.CreatePage()");
        }
    }
    
    public class PdfDocumentWriter : DocumentWriter
    {
        protected override void CreatePage()
        {
            System.Console.WriteLine("PdfDocumentWriter.CreatePage()");
        }
    }
    
    public class HtmlDocumentWriter : DocumentWriter
    {
        protected override void CreatePage()
        {
            System.Console.WriteLine("HtmlDocumentWriter.CreatePage()");
        }
    }
    
    public static class Program
    {
        public static void Main()
        {
            DocumentWriter documentWriter = new PdfDocumentWriter();
            documentWriter.CreateDocument();
            
            // Re-use the same variable. 
            // CreateDocumentwill still call the correct version of CreatePage.
            documentWriter = new HtmlDocumentWriter();
            documentWriter.CreateDocument();
        }
    }
