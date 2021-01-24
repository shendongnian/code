    public ActionResult FileUpload(FileUploadModel fileModel)
    {
        if (ModelState.IsValid)
        {
             using (MemoryStream memoryStream = new MemoryStream())
             {
                  fileModel.File.InputStream.CopyTo(memoryStream);
                  memoryStream.Position = 0;
                  StreamReader s = new StreamReader(memoryStream);
                  JArray array = JArray.Parse(s.ReadToEnd());
                  ...
              }
         }
         return View();
    }
