    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document(PageSize.A4);
            using (var stream = new FileStream("test.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var writer = PdfWriter.GetInstance(doc, stream);
                doc.Open();
                doc.NewPage();
                doc.Add(new Paragraph("Page1 (portrait A4)"));
                doc.NewPage();
                doc.Add(new Paragraph("Page2 (portrait  A4)"));
                // Set page size before calling NewPage
                doc.SetPageSize(PageSize.A4.Rotate());
                doc.NewPage();
                doc.Add(new Paragraph("Page3 (landscape A4)"));
                // Revert to the original page size before adding new pages
                doc.SetPageSize(PageSize.A4);
                doc.NewPage();
                doc.Add(new Paragraph("Page4 (portrait A4)"));
                doc.Close();
            }
        }
