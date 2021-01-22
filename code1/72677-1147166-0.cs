    string fileName = AppDomain.CurrentDomain.BaseDirectory + "Cropper/tests/castle.jpg");
    using (Image image = Image.FromFile(fileName)
    {
        using (Graphics graphic = Graphics.FromImage(image))
        {
            // Crop and resize the image.
            Rectangle destination = new Rectangle(0, 0, 200, 120);
            graphic.DrawImage(image, destination, int.Parse(X1.Value), int.Parse(Y1.Value), int.Parse(Width.Value), int.Parse(Height.Value), GraphicsUnit.Pixel);
        }
        image.Save(fileName);
    }
