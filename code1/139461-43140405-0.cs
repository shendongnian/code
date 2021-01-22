    using (MemoryStream ms = new MemoryStream(image))
    {
        System.Drawing.Image imageFromDB = System.Drawing.Image.FromStream(ms);
    
        Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(image);
        Image1.Width = imageFromDB.Width;
        Image1.Height = imageFromDB.Height;
    }
