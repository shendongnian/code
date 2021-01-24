        public void GetImage(string imageString)
        {
            string imageStringToConvertIntoImage = "";
            if (imageString.Contains(@"data:image/jpeg;base64,"))
            {
                imageStringToConvertIntoImage = imageString.Split(',')[1];
            }
            else
            {
                imageStringToConvertIntoImage = imageString;
            }
            string path = @"E:\\Temp\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!string.IsNullOrEmpty(imageStringToConvertIntoImage))
            {
                string converted = imageStringToConvertIntoImage.Replace('-', '+');
                converted = converted.Replace('_', '/');
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(imageStringToConvertIntoImage)))
                {
                    var pageFilePath = Path.Combine(path, string.Format(DateTime.Now.Ticks.ToString() + "-Image.jpg"));
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                    image.Save(pageFilePath, ImageFormat.Jpeg);
                }
            }
        }
