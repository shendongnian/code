    foreach (string path in files) {
        using (fs = new FileStream(path, FileMode.Open)) 
        {
            using (ms = new MemoryStream()) 
            {
               using(var bmp = new Bitmap(fs))
               {
                  bmp.Save(ms, ImageFormat.Png);
               }
               png = Image.FromStream(ms);
               png.Save(path);
            }
        }
        
    }
