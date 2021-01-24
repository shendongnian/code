    public class MyPdfCreator {
        public MemoryStream GetDocumentStream()
        {
            using (var outStream = new MemoryStream())
            using (var doc = new Document())
            {
                var writer = PdfWriter.GetInstance(doc, outStream);
                doc.Open();
                doc.Add(new Paragraph("Hello World"));
                return outStream;
            }
        }
    }
