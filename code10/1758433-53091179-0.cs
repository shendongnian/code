        [HttpPost]
        public ActionResult UploadFiles()
        {
            string path = Server.MapPath("~/Uploads/");
            var fileExists = Request.Files.Count > 0;
            if (fileExists)
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                try
                {
                    HttpPostedFileBase fileBase = Request.Files[0];
                    if (fileBase != null)
                    {
                        string fileName = Path.GetFileName(fileBase.FileName);
                        fileBase.SaveAs(path + fileName);
                    }
                    
                    return Json(new { success = "true"});
                }
                catch (Exception ex)
                {
                    return Json(new { success = "false", error = ex.Message });
                }
            }
            return Json(new { success = "false"});
        }
