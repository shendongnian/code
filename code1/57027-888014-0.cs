    byte[] imageData;
    using (Bitmap image = new Bitmap(10,10)) {
       using (Graphics g = Graphics.FromImage(image)) {
          g.Clear(Color.Red);
       }
       using (MemoryStream m = new MemoryStream()) {
          image.Save(m, ImageFormat.Png);
          imageData = m.ToArray();
       }
    }
    Response.ContentType = "image/png";
    Response.BinaryWrite(imageData);
