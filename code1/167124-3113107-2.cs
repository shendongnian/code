    public ActionResult Import(FormCollection fc, HttpPostedFileWrapper FileUpload)
    {
      string chkDelete = fc["DeleteExisting"];
      if (null != FileUpload && 0 < FileUpload.ContentLength) {
       // We have an upload.
      
       string filename = FileUpload.FileName;
        if (!chkDelete.Equals("false"))
        {
            //TODO: delete existing records, if specified
        }
        // Stream file in from FileUpload.InputStream e.g.:
        var bytesOriginal = new byte[FileUpload.ContentLength];
        FileUpload.InputStream.Read(bytesOriginal, 0, FileUpload.ContentLength);
        //Read from the byte array as you would any normal file.
      }
      return View();
    }
