    HttpPostedFile File = FileUpload1.PostedFile;
    
    int i = File.ContentLength;
    byte[] Data = new byte[i + 1];
    
    File.InputStream.Read(Data, 0, File.ContentLength);
    
    string sFileName = System.IO.Path.GetFileName(File.FileName.Replace(" ", "_"));
    string p = Server.MapPath("~/images/");
    
    File.SaveAs(p + sFileName);
