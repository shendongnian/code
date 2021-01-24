    var result = Request.Form["FileName"];
                    if(result != null)
                    {
                        string fileLocation = result.ToString();
                        if (!string.IsNullOrEmpty(fileLocation))
                        {
                            var deleteFile = fileLocation.Split('\\')[1];
                            var pathe = Path.Combine(uploadPath, deleteFile;
                            if (System.IO.File.Exists(pathFile))
                            {
                                System.IO.File.Delete(pathFile);
                            }
                        }
                    }
