    using (Bitmap bit = new Bitmap(80, 106)) {
      bit.Clear(Color.White);
      string[] skins = new string[] { "skin1.png", "eyes3.png", "mouth8.png" };
      using (Graphics g = Graphics.FromImage(bit)) {
        foreach (string skin in skins) {
          using (Image skinImage = Image.FromFile(Server.MapPath("/images/" + skin)) {
            g.DrawImage(skinImage, 0, 0, 80, 106);
          }
        }
      }
      Response.ContentType = "image/jpeg";
      bit.Save(Response.OutputStream, ImageFormat.Jpeg);
    }
