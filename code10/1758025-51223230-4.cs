        public void GetImage(string imageString)
        {
            string imageStringToConvertIntoImage = "";
            
            // Check the Base64 string before remove the starting extension like: `data:image/jpeg;base64,`
            if (imageString.Contains(@"data:image/jpeg;base64,"))
            {
                imageStringToConvertIntoImage = imageString.Split(',')[1];
            }
            else
            {
                imageStringToConvertIntoImage = imageString;
            }
            
            // Image path where do you want to store images after convert
            string path = @"E:\\Temp\";
            
            // Check if path is exists or not, If not then create
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!string.IsNullOrEmpty(imageStringToConvertIntoImage))
            {
              // Replace - with +
                string converted = imageStringToConvertIntoImage.Replace('-', '+');
              // From above modified string replace _ with /
                converted = converted.Replace('_', '/');
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(imageStringToConvertIntoImage)))
                {
                    var pageFilePath = Path.Combine(path, string.Format(DateTime.Now.Ticks.ToString() + "-Image.jpg"));
                    // Draw image from memory stream and use Save method to save image file with specified format
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                    image.Save(pageFilePath, ImageFormat.Jpeg);
                }
            }
        }
