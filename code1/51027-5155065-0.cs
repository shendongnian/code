     public class Pdf : IPdf
        {
            public FileStreamResult Make(string s)
            {
                using (var ms = new MemoryStream())
                {
                    using (var document = new Document())
                    {
                        PdfWriter.GetInstance(document, ms);
                        document.Open();
                        using (var str = new StringReader(s))
                        {
    
                            var htmlWorker = new HTMLWorker(document);
    
                            htmlWorker.Parse(str);
                        }
                        document.Close();
                    }
    
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=MyPdfName.pdf");
                    HttpContext.Current.Response.Buffer = true;
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
                    HttpContext.Current.Response.OutputStream.Flush();
                    HttpContext.Current.Response.End();
    
                    return new FileStreamResult(HttpContext.Current.Response.OutputStream, "application/pdf");
                }
            }
        }
