    foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
          {
            string filename = Path.GetFileName(postedFile.FileName);
            string FileExtension = Path.GetExtension(postedFile.FileName);
            string CurrDate = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            for(int i = 1; i <= data.Count;i++)
               {
                 FileUpload1.PostedFile.SaveAs(Server.MapPath("~/InvoiceUploads/") + 
                 "Invoice " 
                  + id + "_" + i + CurrDate + FileExtension);
               }
          }
