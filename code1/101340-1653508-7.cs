        //
        // GET: /FileManager/GetFile/ID
        [OutputCache(Order = 2, Duration = 600, VaryByParam = "ID")]
        public ActionResult GetFile(int ID)
        {
            FileService svc = ObjectFactory.GetInstance<FileService>();
            KsisOnline.Data.File result = svc.GetFileByID(ID);
            return File(result.Data, result.MimeType, result.UploadFileName);
        }
