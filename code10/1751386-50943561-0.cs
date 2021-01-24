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
    
    public static class Program
    {
        public static void Main()
        {
            var documentWriter = new PdfDocumentWriter();
            documentWriter.CreateDocument();
        }
    }
