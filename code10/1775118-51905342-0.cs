      try
        {
            using (var bitmap = new System.Drawing.Bitmap(file.InputStream))
            {
                using (var memoryStream = new MemoryStream())
                {
                     bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                     return memoryStream.ToArray();
                }
            }
       }
       catch (Exception)
            {
                return null;
            }
       finally
            {
                postedFile.InputStream.Position = 0;
            }
