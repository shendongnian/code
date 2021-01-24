    [HttpPost]
            public ActionResult Upload()
            {
                if (Request.Files.Count < 1)
                {
                    ViewBag.Result = "No files were provided";
                    return PartialView("Error");
                }
    
                foreach (string F in Request.Files)
                {
                    var FInfo = Request.Files[F];
                    var TemporaryFileName = $"{FInfo.FileName}.tmp";
    
                    try
                    {
    
                        using (var FStream = new FileStream(TemporaryFileName, FileMode.Create, FileAccess.Write))
                        {
                            FInfo.InputStream.CopyTo(FStream);
                        }
                        
                    }
                    catch (Exception e)
                    {
                        ViewBag.Result = e.Message;
                        return PartialView("Error");
                    }
                    finally
                    {
                        System.IO.File.Move(TemporaryFileName, $"{FInfo.FileName}");
                    }
    
                }
    
                ViewBag.Result = "Files have been uploaded";
    
                return View();
            }
