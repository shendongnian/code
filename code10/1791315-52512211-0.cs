      using (var zip = new ZipFile())
            {
              
                zip.AddEntry("zpn.pdf", bBlob);
                using (var memoryStream = new MemoryStream())
                {
                    zip.Save(memoryStream);
                    HttpContext.Current.Response.ContentType = "application/zip";
                    HttpContext.Current.Response.AddHeader("content-disposition", " inline; filename=\"myfile.zip");
                    HttpContext.Current.Response.BinaryWrite(memoryStream.ToArray());
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    HttpContext.Current.Response.End();
                }
            }
