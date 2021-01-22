        // get the full path of image url
        string path = Server.MapPath(Image1.ImageUrl) ;
    
        // creating image from the image url
        System.Drawing.Image i = System.Drawing.Image.FromFile(path);
    
        // rotate Image 90' Degree
        i.RotateFlip(RotateFlipType.Rotate90FlipXY);
    
        // save it to its actual path
        i.Save(path);
    
        // release Image File
        i.Dispose();
    
        // Set Image Control Attribute property to new image(but its old path)
        Image1.Attributes.Add("ImageUrl", path);
