    public string CreateDeepZoomImage(byte[] abyte, string fileName)
            {
                ImageCreator ic = new ImageCreator();
                string FilePath = Path.Combine(_uploadPath, fileName);
                System.IO.FileStream fs = new System.IO.FileStream(FilePath, System.IO.FileMode.Create);
                fs.Write(abyte, 0, abyte.Length);
                fs.Close();
                FileInfo imageFileInfo = new FileInfo(FilePath);
                string destination = imageFileInfo.DirectoryName + "\\" + imageFileInfo.Name.TrimEnd(imageFileInfo.Extension.ToCharArray()) + "\\output.xml";
                ic.Create(FilePath, destination);
                string returnpath = "/Uploads/" + imageFileInfo.Name.TrimEnd(imageFileInfo.Extension.ToCharArray()) + "/output.xml";
                return returnpath;
            }
