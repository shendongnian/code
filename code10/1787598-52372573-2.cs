    private void Page(object sender, PrintPageEventArgs e)
    {
        using (Bitmap i = image)  //are you *really sure* you want to dispose this after printing? 
        {
            var pageRatio = e.PageBounds.Width / (double)e.PageBounds.Height;
            var imageRatio = i.Width / (double)i.Height;
            //do we need to rotate?
            if ( (pageRatio < 1 && imageRatio > 1) || (pageRatio < 1 && imageRatio > 1))
            {
                i.RotateFlip(RotateFlipType.Rotate90FlipNone);
                imageRatio = i.Width / (double)i.Height; //ratio will have changed after rotation
            }         
            int T = 0, L = 0; //top, left
            var scale = 1.0D;
            int W = i.Width, H = i.Height;
            //do we need to scale?
            if (pageRatio > imageRatio)
            { //the page is wider than the image, so scale to the height
                 scale = e.PageBounds.Height / (double)i.Height;
                 W = (int)(scale * i.Width); 
                 H = (int)(scale * i.Height);
                 L = (e.PageBounds.Width - W)/2;
            }
            else if (pageRatio < imageRatio)
            { //the page is narrower than the image, so scale to width
                scale = e.PageBounds.Width / (double)i.Width;
                W = (int)(scale * i.Width); 
                H = (int)(scale * i.Height);
                T = (e.PageBounds.Height - H)/2;
            }
     
            e.Graphics.DrawImage(i, new Rectangle(L, T, W, H));
        }
    }
