    public MemoryStream CreateMemoryStream()
    {
        byte[] dynamicPdfBytes;
        using (var dynamicPDfMemoryStream = new MemoryStream())
        {
            using (var document = new Document(PageSize.A4, 25, 25, 30, 30))
            {
                PdfWriter.GetInstance(document, dynamicPDfMemoryStream);
                document.Open();
                var pdfPTable = new PdfPTable(1)
                {
                    TotalWidth = _totalWidth,
                    LockedWidth = true,
                    SpacingBefore = _spacingBefore,
                    SpacingAfter = _spacingAfter
                };
                float[] widths = { 272f };
                pdfPTable.SetWidths(widths);
                var image = Image.GetInstance(HttpContext.Current.Server.MapPath("/Images/logo.png"));
                image.ScaleToFit(125f, 125f);
                image.Alignment = Image.RIGHT_ALIGN;
                var pdfPCell = new PdfPCell(image)
                {
                    Border = 0,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                };
                pdfPTable.AddCell(pdfPCell);
                document.Add(pdfPTable);
            }
            dynamicPdfBytes = dynamicPDfMemoryStream.ToArray();
        }
        byte[] pdfBytes;
        using (var pdfReader = new PdfReader(HttpContext.Current.Server.MapPath("/Documents/Test.pdf")))
        {
            using (var pdfMemoryStream = new MemoryStream())
            {
                var pdfStamper = new PdfStamper(pdfReader, pdfMemoryStream);
                var acroFields = pdfStamper.AcroFields;
                acroFields.SetField("TestField", "This is a test");
                pdfStamper.FormFlattening = true;
                pdfStamper.Close();
                pdfBytes = pdfMemoryStream.ToArray();
            }
        }
        var files = new List<byte[]> { dynamicPdfBytes, pdfBytes };
        byte[] array;
        using (var arrayMemoryStream = new MemoryStream())
        {
            var document = new Document(PageSize.A4, 25, 25, 30, 30);
            var pdfWriter = PdfWriter.GetInstance(document, arrayMemoryStream);
            document.Open();
            var directContent = pdfWriter.DirectContent;
            foreach (var bytes in files)
            {
                var pdfReader = new PdfReader(bytes);
                var numberOfPages = pdfReader.NumberOfPages;
                for (var i = 1; i <= numberOfPages; i++)
                {
                    document.NewPage();
                    var page = pdfWriter.GetImportedPage(pdfReader, i);
                    directContent.AddTemplate(page, 0, 0);
                }
            }
            document.Close();
            array = arrayMemoryStream.ToArray();
        }
        var memoryStream = new MemoryStream();
        memoryStream.Write(array, 0, array.Length);
        memoryStream.Position = 0;
        return memoryStream;
    }
