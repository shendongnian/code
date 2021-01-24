    Bitmap textile = new Bitmap("textile.png");
            TextureBrush textileBrush = new TextureBrush(textile);
            Bitmap outfit = new Bitmap("outfit.png");
            Bitmap masksource = new Bitmap("mask.png");
            Bitmap transparentImage = new Bitmap(outfit.Width, outfit.Height);
            masksource.MakeTransparent(Color.FromArgb(255, 0, 255, 0));
            using (Graphics g = Graphics.FromImage(transparentImage))
            {
                g.DrawImage(outfit, new Point(0, 0));
                //g.DrawImage(textile, new Point(0, 0)); // use texture image
                g.FillRectangle(textileBrush, g.ClipBounds); // use texture image as Tile mode
                g.DrawImage(masksource, new Point(0, 0));
                transparentImage.MakeTransparent(Color.FromArgb(255, 255, 0, 0));
                transparentImage.MakeTransparent(Color.FromArgb(255, 0, 0, 255));
            }
            Bitmap outputImage = new Bitmap(outfit.Width, outfit.Height);
            using (Graphics g = Graphics.FromImage(outputImage))
            {
                g.DrawImage(outfit, new Point(0, 0));
                g.DrawImage(transparentImage, new Point(0, 0));
            }
