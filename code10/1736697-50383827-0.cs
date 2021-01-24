    using (var stream = File.Create("test.pdf"))
    using (var doc = new Document())
    using (var pdfWriter = PdfWriter.GetInstance(doc, stream))
    {
        doc.Open();
        foreach (var file in ofd.SafeFileNames)
        {
            using (var imageStream = File.OpenRead(file))
            {
                var image = Image.GetInstance(imageStream);
                doc.Add(image);
            }
        }
        doc.Close();
    }
