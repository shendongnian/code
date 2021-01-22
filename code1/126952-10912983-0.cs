        Bitmap ret = new Bitmap(bWidth, bHeight, 
                                System.Drawing.Imaging.PixelFormat.Format32bppArgb);    
        ret.MakeTransparent(Color.White);     // Change a color to be transparent
        Image img = (Image) ret;
        img.Save(filename, ImageFormat.Png);  // Correct PNG save
