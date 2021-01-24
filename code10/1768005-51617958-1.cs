    public class MyPdfCreator {
        public MemoryStream GetDocumentStream()
        {
            var outStream = new MemoryStream();
            using (var writer = PdfWriter.GetInstance(new Document(), outStream))
                {
                    //stop the writer from closing the stream when the writer is disposed.
                    writer.CloseStream = false;
                    //write document
                }
            return outStream;
        }
    }
