    public void UploadFiles(FormCollection form, NameValueCollection currentFiles)
        {
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file];
                if (hpf.ContentLength == 0)
                {
                    form[file] = currentFiles[file];
                }
                else
                {
                    var filename = hpf.FileName.Replace(" ", "_").Replace(".", DateTime.Now.Date.Ticks + ".");
                    UploadFileName = filename;
                    hpf.SaveAs(Server.MapPath("~/Content/custom/" + filename));
                    form[file] = UploadFileName;
                }
            }
            if(Request.Files.Count <= 0)
            {
                foreach (var file in currentFiles.AllKeys)
                {
                    form[file] = currentFiles[file];
                }
            }
        }
