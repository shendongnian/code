            string bitmapString = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, ImageFormat.Png); 
                byte[] bitmapBytes = memoryStream.GetBuffer();
                bitmapString = Convert.ToBase64String(bitmapBytes, Base64FormattingOptions.InsertLineBreaks);
            }
