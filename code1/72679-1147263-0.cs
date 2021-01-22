    using (Image image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "Cropper/tests/castle.jpg")) {
    
       // Create bitmap
       using (Bitmap newImage = new Bitmap(200, 120)) {
    
          // Crop and resize the image.
          Rectangle destination = new Rectangle(0, 0, 200, 120);
          using (Graphics graphic = Graphics.FromImage(newImage)) {
             graphic.DrawImage(image, destination, int.Parse(X1.Value), int.Parse(Y1.Value), int.Parse(Width.Value), int.Parse(Height.Value), GraphicsUnit.Pixel);
          }
          newImage.Save(AppDomain.CurrentDomain.BaseDirectory + "Cropper/tests/castle_icon.jpg", ImageFormat.Jpeg);
       }
    }
