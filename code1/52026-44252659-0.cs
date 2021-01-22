    using ...;
    using PdfSharp.Pdf;
    using PdfSharp.Pdf.IO;
    public static class PdfHelper
    {
        public static byte[] PdfConcat(List<byte[]> lstPdfBytes)
        {
            byte[] res;
    
            using (var outPdf = new PdfDocument())
            {
                foreach (var pdf in lstPdfBytes)
                {
                    using (var pdfStream = new MemoryStream(pdf))
                    using (var pdfDoc = PdfReader.Open(pdfStream, PdfDocumentOpenMode.Import))
                        for (var i = 0; i < pdfDoc.PageCount; i++)
                            outPdf.AddPage(pdfDoc.Pages[i]);
                }
    
                using (var memoryStreamOut = new MemoryStream())
                {
                    outPdf.Save(memoryStreamOut, false);
    
                    res = Stream2Bytes(memoryStreamOut);
                }
            }
    
            return res;
        }
        public static void DownloadAsPdfFile(string fileName, byte[] content)
        {
            var ms = new MemoryStream(content);
    
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("content-disposition", $"attachment;filename={fileName}.pdf");
            HttpContext.Current.Response.Buffer = true;
            ms.WriteTo(HttpContext.Current.Response.OutputStream);
            HttpContext.Current.Response.End();
        }
        private static byte[] Stream2Bytes(Stream input)
        {
            var buffer = new byte[input.Length];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, read);
                return ms.ToArray();
            }
        }
    }
