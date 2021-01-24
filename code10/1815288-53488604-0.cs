    public void ProcessRequest(HttpContext archivo)
            {
                var re = HttpContext.Current.Request.Form["archivo"];
                archivo.Response.ContentType = "text/plain";
    
                string dirFullPath = HttpContext.Current.Server.MapPath("~/files/");
                string[] files;
                int numFiles;
                files = System.IO.Directory.GetFiles(dirFullPath);
                numFiles = files.Length;
                numFiles = numFiles + 1;
                string str_image = "";
                foreach (string s in archivo.Request.Files)
                {
                    HttpPostedFile file = archivo.Request.Files[s];
                    string fileName = file.FileName;
                    string fileExtension = file.ContentType;
    
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        fileExtension = System.IO.Path.GetExtension(fileName);
                        str_image = "MyPHOTO_" + numFiles.ToString() + fileExtension;
                        string pathToSave_100 = HttpContext.Current.Server.MapPath("~/files/") + str_image;
                        file.SaveAs(pathToSave_100);
                    }
                }
                archivo.Response.Write(str_image);
            }
