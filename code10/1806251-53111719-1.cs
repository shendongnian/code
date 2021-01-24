    public ActionResult FileUpload(FileModel fileModel)
    {
        if (ModelState.IsValid)
        {
             StreamReader s = new StreamReader(fileModel.File.InputStream);
             JArray array = JArray.Parse(s.ReadToEnd());
             ...
         }
         return View();
    }
