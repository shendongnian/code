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
            var scale = 1.0D;
            //do we need to scale?
            if (pageRatio > imageRatio)
            { //the page is wider than the image, so scale to the height
                 scale = e.PageBounds.Height / (double)i.Height;
            }
            else if (pageRatio < imageRatio)
            { //the page is narrower than the image, so scale to width
                scale = e.PageBounds.Width / (double)i.Width;
            }
            var W = (int)(scale * i.Width);
            var H = (int)(scale * i.Height);
          
            e.Graphics.DrawImage(i, new Rectangle(0, 0, W, H));
        }
    }
