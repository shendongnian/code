    WriteableBitmap bm = new WriteableBitmap( 100, 100, 96, 96, PixelFormats.Pbgra32, null );
    bm.Lock();
    
    Bitmap bmp = new Bitmap( bm.PixelWidth, bm.PixelHeight, bm.BackBufferStride, System.Drawing.Imaging.PixelFormat.Format32bppArgb, bm.BackBuffer );
    using( Graphics g = Graphics.FromImage( bmp ) ) {
    	var color = System.Drawing.Color.FromArgb( 20, System.Drawing.Color.Blue);
    	g.FillRectangle(
    		new System.Drawing.SolidBrush( color ),
    		new RectangleF( 0, 0, bmp.Width, bmp.Height ) );
    }
    
    bmp.Save( @".\000_foo.bmp", System.Drawing.Imaging.ImageFormat.Bmp );
    bmp.Save( @".\000_foo.jpg", System.Drawing.Imaging.ImageFormat.Jpeg );
    bmp.Save( @".\000_foo.png", System.Drawing.Imaging.ImageFormat.Png );
    bmp.Dispose();
    
    bm.AddDirtyRect( new Int32Rect( 0, 0, bm.PixelWidth, bm.PixelHeight ) );
    bm.Unlock();
