    // create image to draw on
    using (Bitmap bit = new Bitmap(80, 106)) {
      // fill with background
      bit.Clear(Color.White);
      // images to load
      string[] skins = new string[] { "skin1.png", "eyes3.png", "mouth8.png" };
      // create graphics object for drawing on the bitmap
      using (Graphics g = Graphics.FromImage(bit)) {
        foreach (string skin in skins) {
          // load image
          using (Image skinImage = Image.FromFile(Server.MapPath("/images/" + skin)) {
            // draw image
            g.DrawImage(skinImage, 0, 0, 80, 106);
          }
        }
      }
      Response.ContentType = "image/jpeg";
      bit.Save(Response.OutputStream, ImageFormat.Jpeg);
    }
