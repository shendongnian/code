            [AllowAnonymous]
            //-------------------------------------------------------------
            public async Task<ActionResult> RandomBackground()
            //-------------------------------------------------------------
            {
                var basePath = "~/Content/images/backgrounds";
                var dir = System.Web.Hosting.HostingEnvironment.MapPath(basePath);
    
                var rand = new Random();
                var files = System.IO.Directory.GetFiles(dir, "*.jpg");
                if (files!=null)
                {
                    var cookie = "Background";
                    var pickedFile = "";
                    var fileName = "";
                    var oldFilename = "";
                    while ((oldFilename == fileName) && files.Count<string>()>1)
                    {
                        oldFilename = ReadControllerCookie(cookie);
                        pickedFile = files[rand.Next(files.Length)];
                        fileName = System.IO.Path.GetFileName(pickedFile);
                    }
                    SaveControllerCookie(cookie, fileName);
                    return Content(fileName);
                }
                return new EmptyResult();
            }
