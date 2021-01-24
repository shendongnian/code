                //Conversion of the ASPX file into PDF
                MemoryStream rend=Renderer.RenderUrlAsPdf(val).Stream;
                HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");
                // let the browser know how to open the PDF document, attachment or inline, and the file name
                HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("{0}; filename=Print.pdf; size={1}",
                  "attachment", rend.Length.ToString()));
                // write the PDF buffer to HTTP response
                HttpContext.Current.Response.BinaryWrite(rend.ToArray());
                // call End() method of HTTP response to stop ASP.NET page processing
                HttpContext.Current.Response.End();
