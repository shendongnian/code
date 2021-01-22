      public override void OnStartPage(PdfWriter writer, Document document)
            {
                if (condition)
                {
                    string watermarkText = "-whatever you want your watermark to say-";
                    float fontSize = 80;
                    float xPosition = 300;
                    float yPosition = 400;
                    float angle = 45;
                    try
                    {
                        PdfContentByte under = writer.DirectContentUnder;
                        BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.EMBEDDED);
                        under.BeginText();
                        under.SetColorFill(iTextSharp.text.pdf.CMYKColor.LIGHT_GRAY);
                        under.SetFontAndSize(baseFont, fontSize);
                        under.ShowTextAligned(PdfContentByte.ALIGN_CENTER, watermarkText, xPosition, yPosition, angle);
                        under.EndText();
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex.Message);
                    }
                }
            }
