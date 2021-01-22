    byte[] data;
    using(System.IO.MemoryStream stream = new System.IO.MemoryStream()) {
       bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
       stream.Position = 0;
       data = new byte[stream.Length];
       stream.Read(data, 0, stream.Length);
       stream.Close();
    }
