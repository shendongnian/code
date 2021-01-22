    class MyCanvas : Canvas {
       protected override void OnRender (DrawingContext dc) {
          BitmapImage img = new BitmapImage (new Uri ("c:\\demo.jpg"));
          dc.DrawImage (img, new Rect (0, 0, img.PixelWidth, img.PixelHeight));
       }
    }
