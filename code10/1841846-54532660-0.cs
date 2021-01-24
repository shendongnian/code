    iTextSharp.text.Font blackFont = FontFactory.GetFont("Arial", 12,
        iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
    using (Stream source = File.OpenRead(theFile))
    using (Stream dest = File.Create(@"C:\Users\user\Pictures\Camera Roll\PDF.pdf"))
    {
        PdfReader reader = new PdfReader(source);
        using (PdfStamper stamper = new PdfStamper(reader, dest))
        {
            int pages = reader.NumberOfPages;
            for (int i = 1; i <= pages; i++)
            {
                ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_RIGHT,
                    new Phrase(i.ToString(), blackFont), 568f, 15f, 0);
            }
        }
    }
