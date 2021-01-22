        class PdfWriterEvents : IPdfPageEvent
        {
            string watermarkText = string.Empty;
    
            public PdfWriterEvents(string watermark) 
            {
                watermarkText = watermark;
            }
    
            public void OnOpenDocument(PdfWriter writer, Document document) { }
            public void OnCloseDocument(PdfWriter writer, Document document) { }
            public void OnStartPage(PdfWriter writer, Document document) {
                float fontSize = 80;
                float xPosition = 300;
                float yPosition = 400;
                float angle = 45;
                try
                {
                    PdfContentByte under = writer.DirectContentUnder;
                    BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.EMBEDDED);
                    under.BeginText();
                    under.SetColorFill(BaseColor.LIGHT_GRAY);
                    under.SetFontAndSize(baseFont, fontSize);
                    under.ShowTextAligned(PdfContentByte.ALIGN_CENTER, watermarkText, xPosition, yPosition, angle);
                    under.EndText();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
            }
            public void OnEndPage(PdfWriter writer, Document document) { }
            public void OnParagraph(PdfWriter writer, Document document, float paragraphPosition) { }
            public void OnParagraphEnd(PdfWriter writer, Document document, float paragraphPosition) { }
            public void OnChapter(PdfWriter writer, Document document, float paragraphPosition, Paragraph title) { }
            public void OnChapterEnd(PdfWriter writer, Document document, float paragraphPosition) { }
            public void OnSection(PdfWriter writer, Document document, float paragraphPosition, int depth, Paragraph title) { }
            public void OnSectionEnd(PdfWriter writer, Document document, float paragraphPosition) { }
            public void OnGenericTag(PdfWriter writer, Document document, Rectangle rect, String text) { }
    
        }
    }
