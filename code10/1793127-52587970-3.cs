        private string SaveImage(string base64, string FilePath, string ImageName)
        {
            //Get the file type to save in
            var FilePathWithExtension = "";
            string localBase64 = "";
            if (base64.Contains("data:image/jpeg;base64,"))
            {
                FilePathWithExtension = FilePath + ImageName + ".jpg";
                localBase64 = base64.Replace("data:image/jpeg;base64,", "");
            }
            else if (base64.Contains("data:image/png;base64,"))
            {
                FilePathWithExtension = FilePath + ImageName + ".png";
                localBase64 = base64.Replace("data:image/png;base64,", "");
            }
            else if (base64.Contains("data:image/bmp;base64"))
            {
                FilePathWithExtension = FilePath + ImageName + ".bmp";
                localBase64 = base64.Replace("data:image/bmp;base64", "");
            }
            else if (base64.Contains("data:application/msword;base64,"))
            {
                FilePathWithExtension = FilePath + ImageName + ".doc";
                localBase64 = base64.Replace("data:application/msword;base64,", "");
            }
            else if (base64.Contains("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64,"))
            {
                FilePathWithExtension = FilePath + ImageName + ".docx";
                localBase64 = base64.Replace("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64,", "");
            }
            else if (base64.Contains("data:application/pdf;base64,"))
            {
                FilePathWithExtension = FilePath + ImageName + ".pdf";
                localBase64 = base64.Replace("data:application/pdf;base64,", "");
            }
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(localBase64)))
            {
                using (FileStream fs = new FileStream(FilePathWithExtension, FileMode.Create, FileAccess.Write))
                {
                    //Create the specified directory if it does not exist
                    var photofolder = System.IO.Path.GetDirectoryName(FilePathWithExtension);
                    if (!Directory.Exists(photofolder))
                    {
                        Directory.CreateDirectory(photofolder);
                    }
                    ms.WriteTo(fs);
                    fs.Close();
                    ms.Close();
                }
            }
            return FilePathWithExtension;
        }
