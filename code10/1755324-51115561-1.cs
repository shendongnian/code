    foreach (string path in files) {
       using (var ms = new MemoryStream()) //keep stream around
       {
            using (var fs = new FileStream(path, FileMode.Open)) // keep file around
            {
                // create and save bitmap to memorystream
                using(var bmp = new Bitmap(fs))
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            // write the PNG back to the same file from the memorystream
            using(var png = Image.FromStream(ms))
            {
                png.Save(path);
            }
        }
    }
