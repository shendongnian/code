    Bitmap orig = new Bitmap(@imagenamecm);
                    //imagenamecm is the link to the 8bit-greyscale image
                    Bitmap clone = new Bitmap(orig.Width, orig.Height,
                        System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
    
                    using (Graphics gr = Graphics.FromImage(clone))
                    {
                        gr.DrawImage(orig, new Rectangle(0, 0, clone.Width, clone.Height));
                    }
                        clone.Save(imagenamecmrgb, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //  imagenamecmrgb is the path for the greyscale rgb image
