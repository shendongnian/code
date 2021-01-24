    public class MyPdfCreator 
    {
        public MemoryStream GetDocumentStream()
        {
            var ms = new MemoryStream();
            var doc = new Document();
            var writer = PdfWriter.GetInstance(doc, ms);
            writer.CloseStream = false;
            doc.Open();
            doc.Add(new Paragraph("Hello World"));
            doc.Close();
            writer.Close();
            return ms;
        }
    }
