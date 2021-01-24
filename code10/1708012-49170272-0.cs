    using (MemoryStream stream = new MemoryStream())
    {
        PdfReader reader = new PdfReader(bytes);
        using (PdfStamper stamper = new PdfStamper(reader, stream))
        {
            //stamper.FormFlattening = true;
            int pages = reader.NumberOfPages;
            for (int i = 1; i <= pages; i++)
            {
                Rectangle cropBox = reader.GetCropBox(i);
                ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_RIGHT,
                    new Phrase("Generated ECAB", blackFont), cropBox.GetRight(44f), cropBox.GetBottom(15f), 0);
            }
        }
        bytes = stream.ToArray();
    }
