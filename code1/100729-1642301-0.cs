    class Program
    {
        static void Main(string[] args)
        {
            Document document = new Document();
            using (var stream = new FileStream("test.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();
                using (var imageStream = new FileStream("test.jpg", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var image = Image.GetInstance(imageStream);
                    document.Add(image);
                }
                document.Close();
            }
        }
    }
