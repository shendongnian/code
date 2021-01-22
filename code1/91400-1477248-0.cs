            Image bmp = new Bitmap(10, 10);
            byte[] array = ImageToByteArray(bmp);
            public byte[] ImageToByteArray(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif );
            return ms.ToArray();
        }
