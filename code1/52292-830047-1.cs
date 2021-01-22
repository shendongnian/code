    protected void DisplayPDFEnvelope()
        {
            try
            {
                PdfDocument document = new PdfDocument();
                PdfPage pdfpage = new PdfPage();
    
                XUnit pdfWidth = new XUnit(4.125, XGraphicsUnit.Inch);
                XUnit pdfHeight = new XUnit(9.5, XGraphicsUnit.Inch);
                pdfpage.Height = pdfHeight;
                pdfpage.Width = pdfWidth;
    
                pdfpage.Orientation = PageOrientation.Landscape;
    
                XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
    
                document.AddPage(pdfpage);
    
                // Create a font
                XFont font = new XFont("ARIAL", 1, XFontStyle.Regular, options);
    
                // Get an XGraphics object for drawing beneath the existing content
                XGraphics gfx = XGraphics.FromPdfPage(pdfpage, XGraphicsPdfPageOptions.Append);
                
                // This method just returns a formatted address from the DB using \n to
                // do line breaks, i.e. 'Test Person\nAddress Line1\City, State Zip'
                string address = GetAddress();
    
                // Get the size (in point) of the text
                XSize size = gfx.MeasureString(address, font);
    
                // Create a graphical path
                XGraphicsPath path = new XGraphicsPath();
    
                path.AddString(address, font.FontFamily, XFontStyle.Regular, 10,
                  new XPoint(345, 160), XStringFormats.Default);
    
                // Create a dimmed pen and brush
                XPen pen = new XPen(XColor.FromGrayScale(0), 0); // XColor.FromArgb(50, 75, 0, 130), 3);
                XBrush brush = new XSolidBrush();   // XColor.FromArgb(50, 106, 90, 205));
    
                // Stroke the outline of the path
                gfx.DrawPath(pen, brush, path);
    
                MemoryStream stream = new MemoryStream();
                document.Save(stream, false);
    
                Page.Response.Clear();
                Page.Response.ContentType = "application/pdf";
                Page.Response.AppendHeader("Content-Length", stream.Length.ToString());
                Page.Response.AppendHeader("Content-Type", "application/pdf");
                Page.Response.AppendHeader("Content-Disposition", "inline;filename=envelope.pdf");
                Page.Response.BinaryWrite(stream.ToArray());
                Page.Response.Flush();
                stream.Close();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
