    public static void ImagesToPdf(string[] imagepaths, string pdfpath)
    {
        using(var doc = new iTextSharp.text.Document())
        {
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(pdfpath, FileMode.Create));
            doc.Open();
            foreach (var item in imagepaths)
            {
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(item);
                doc.Add(image);
            }
        }
    }
