    public static void AddWatermarkTextC(string sourceFile, string outputFile, string watermarkText)
        {
            BaseFont tWatermarkFont = null;
            float tWatermarkFontSize = 48F;
            iTextSharp.text.BaseColor tWatermarkFontColor = null;
            float tWatermarkFontOpacity = 0.3F;
            float tWatermarkRotation = 45.0F;
            tWatermarkFont = iTextSharp.text.pdf.BaseFont.CreateFont(iTextSharp.text.pdf.BaseFont.HELVETICA, iTextSharp.text.pdf.BaseFont.CP1252, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
            tWatermarkFontColor = iTextSharp.text.BaseColor.RED;
            AddWatermarkTextC(sourceFile, outputFile, watermarkText, tWatermarkFont, tWatermarkFontSize, tWatermarkFontColor, tWatermarkFontOpacity, tWatermarkRotation);
        }
    public static void AddWatermarkTextC(string sourceFile, string outputFile, string watermarkText, iTextSharp.text.pdf.BaseFont watermarkFont, float watermarkFontSize, iTextSharp.text.BaseColor watermarkFontColor, float watermarkFontOpacity, float watermarkRotation)
        {
            iTextSharp.text.pdf.PdfReader reader = null;
            iTextSharp.text.pdf.PdfStamper stamper = null;
            iTextSharp.text.pdf.PdfGState gstate = null;
            iTextSharp.text.pdf.PdfContentByte underContent = null;
            iTextSharp.text.Rectangle rect = null;
            float currentY = 0.0F;
            float offset = 0.0F;
            int pageCount = 0;
            try
            {
                reader = new iTextSharp.text.pdf.PdfReader(sourceFile);
                rect = reader.GetPageSizeWithRotation(1);
                FileStream stream = new System.IO.FileStream(outputFile, System.IO.FileMode.Create);
                stamper = new iTextSharp.text.pdf.PdfStamper(reader, stream);
                if (watermarkFont == null)
                {
                    watermarkFont = iTextSharp.text.pdf.BaseFont.CreateFont(iTextSharp.text.pdf.BaseFont.HELVETICA, iTextSharp.text.pdf.BaseFont.CP1252, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
                }
                if (watermarkFontColor == null)
                {
                    watermarkFontColor = iTextSharp.text.BaseColor.RED;
                }
                gstate = new iTextSharp.text.pdf.PdfGState();
                gstate.FillOpacity = watermarkFontOpacity;
                gstate.StrokeOpacity = watermarkFontOpacity;
                pageCount = reader.NumberOfPages;
                for (int i = 1; i <= pageCount; i++)
                {
                    underContent = stamper.GetOverContent(i);
                    underContent.SaveState();
                    underContent.SetGState(gstate);
                    underContent.SetColorFill(watermarkFontColor);
                    underContent.BeginText();
                    underContent.SetFontAndSize(watermarkFont, watermarkFontSize);
                    underContent.SetTextMatrix(30, 30);
                    currentY = (rect.Height / 2);
                    underContent.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, watermarkText, rect.Width / 2, currentY - offset, watermarkRotation);
                    underContent.EndText();
                    underContent.RestoreState();
                }
                stamper.Close();
                reader.Close();
                stream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  
