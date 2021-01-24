    void SendFile()
    {
       foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
       {
          string filename = Path.GetFileName(postedFile.FileName);
          string FileExtension = Path.GetExtension(postedFile.FileName);
          
          // Add a delay
          Thread.Sleep(100);
          for(int i = 1; i <= data.Count;i++){
            postedFile.SaveAs(Server.MapPath("~/InvoiceUploads/") + "Invoice " + id + "_" + i + FileExtension);
        }
    }
}
    
