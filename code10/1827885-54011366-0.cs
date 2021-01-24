        public ActionResult YourController(FormCollection data)
        {
            if (Request.Files.Count > 0)
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //you can save the file like this
                    string path = Server.MapPath("~/Yourpath/FileName" + fileName.Substring(fileName.LastIndexOf('.')));
                    file.SaveAs(path);
                    //or you can load it to memory like this
                    MemoryStream ms = new MemoryStream();
                    file.InputStream.CopyTo(ms);
                    //use it how you like
                }
            }            
            return View();
        }
