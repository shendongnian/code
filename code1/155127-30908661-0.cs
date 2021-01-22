                    HttpPostedFileBase file = this.Request.Files["Upload"];
                    if (file != null)
                    {
                        var fileName = file.FileName;
                        var fileExtension = Path.GetExtension(fileName);
                        filePath = fileName.Replace(fileName, emailTemplateImage.token + fileExtension);
                        var imagepath = Server.MapPath("/Upload/EmailTemplateImage/") + filePath;
                        if (!System.IO.Directory.Exists(filePath))
                        {
                            System.IO.Directory.CreateDirectory(filePath);
                        }
                        file.SaveAs(imagepath);
                    }
