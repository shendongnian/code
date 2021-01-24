            string imgFile = "testimg.jpg";
            System.Drawing.Image image = System.Drawing.Image.FromFile(imgFile);
            PdfDocument pdfDoc = new PdfDocument();
            PdfPage pdfPage = pdfDoc.AddPage(new PdfCustomPageSize((float)image.Width * 0.75f, (float)image.Height * 0.75f), new PdfMargins(0), image.Width > image.Height ? PdfPageOrientation.Landscape : PdfPageOrientation.Portrait);
            PdfImageElement pdfImage = new PdfImageElement(0, 0, image);
            pdfPage.Add(pdfImage);
            pdfDoc.Save("testimg.pdf");
            pdfDoc.Close();
