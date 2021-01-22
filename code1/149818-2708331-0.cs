    public void UploadFiles(FormCollection form, string folder)
        {
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file];
                if (hpf.ContentLength == 0)
                {
                    form[file] = null;
                }
                else
                {
                    var filename = hpf.FileName.Replace(" ", "_").Replace(".", DateTime.Now.Date.Ticks + ".");
                    UploadFileName = filename;
                    hpf.SaveAs(Server.MapPath("~/Content/" + folder + "/" + filename));
                    form[file] = UploadFileName;
                }
            }
            
        }
