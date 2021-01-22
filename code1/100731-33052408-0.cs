    public void ImagesToPdf(string[] imagepaths, string pdfpath)
            {
                iTextSharp.text.Rectangle pageSize = null;
    
                using (var srcImage = new Bitmap(imagepaths[0].ToString()))
                {
                    pageSize = new iTextSharp.text.Rectangle(0, 0, srcImage.Width, srcImage.Height);
                }
                using (var ms = new MemoryStream())
                {
                    var document = new iTextSharp.text.Document(pageSize, 0, 0, 0, 0);
                    iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms).SetFullCompression();
                    document.Open();
                    var image = iTextSharp.text.Image.GetInstance(imagepaths[0].ToString());
                    document.Add(image);
                    document.Close();
    
                    File.WriteAllBytes(pdfpath+"cheque.pdf", ms.ToArray());
                }
            }
