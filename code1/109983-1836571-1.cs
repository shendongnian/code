            int width = plotPrinter.Size.Width;
            int height = plotPrinter.Size.Height;
            Bitmap bm = new Bitmap(width, height);
            plotPrinter.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
            bm.Save(@"D:\TestDrawToBitmap.bmp", ImageFormat.Bmp);
        
