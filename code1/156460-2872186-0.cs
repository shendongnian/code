                            string storePath = Server.MapPath("~") + "/MultipleUpload";
                            if (!Directory.Exists(storePath))
                                Directory.CreateDirectory(storePath);
                            string tempPath = "Galleryt";
                            string imgPath = "Gallery";
                            string savePath = Path.Combine(Request.PhysicalApplicationPath, tempPath);
                            string imgSavePath = Path.Combine(Request.PhysicalApplicationPath, imgPath);
                            string imgSavePath2 = Path.Combine(Request.PhysicalApplicationPath, imgPath);
                            string ProductImageNormal = Path.Combine(imgSavePath, imageName + hif.PostedFile.FileName);
                            string ProductImagetemp = Path.Combine(savePath, "t__" + imageName + hif.PostedFile.FileName);
                            string ProductImagetemp2 = Path.Combine(imgSavePath2, "b__" + imageName + hif.PostedFile.FileName);
                            string extension = Path.GetExtension(hif.PostedFile.FileName);
                            switch (extension.ToLower())
                            {
                                case ".png": goto case "Upload";
                                case ".gif": goto case "Upload";
                                case ".jpg": goto case "Upload";
                                case "Upload": hif.PostedFile.SaveAs(ProductImageNormal);
                                    ImageTools.GenerateThumbnail(ProductImageNormal, ProductImagetemp, 600, 600, true, "heigh");
                                    ImageTools.GenerateThumbnail(ProductImageNormal, ProductImagetemp2, 250, 350, true, "heigh");
                                   
                                    Label1.Text = "";
                                    break;
                                default:
                                    Label1.Text = "Status: Denne filtype er ikke tilladt";
                                    return;
                            }
