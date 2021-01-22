    public static void ImagesToPdf(string[] imagepaths, string pdfpath)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            try
            {
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(pdfpath, FileMode.Create));
                doc.Open();
                foreach (var item in imagepaths)
                {
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(item);
                    doc.Add(image);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                doc.Close();
            }
        }
