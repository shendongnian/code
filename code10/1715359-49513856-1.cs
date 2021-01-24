            //gets the canvas content
            public static void SaveCanvas(Window window, Canvas canvas, int dpi)
            {
    
                var rtb = new RenderTargetBitmap(
                    (int)canvas.Width, //width 
                    (int)canvas.Height, //height 
                    dpi, //dpi x 
                    dpi, //dpi y 
                    PixelFormats.Pbgra32 // pixelformat 
                    );
                rtb.Render(canvas);
                SaveRTBAsPNG(rtb;
            }
            // convert the canvas to png and creat a transparent Icon
            private static void SaveRTBAsPNG(RenderTargetBitmap bmp)
            {
                PngBitmapEncoder enc = new PngBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bmp));
                MemoryStream iconStreamBlue = new MemoryStream();
                enc.Save(iconStreamBlue);
                Bitmap bmpa =(Bitmap)System.Drawing.Image.FromStream(iconStreamBlue);
                IntPtr Hicon = bmpa.GetHicon();
                Icon myIcon = System.Drawing.Icon.FromHandle(Hicon);
                //Set the icon to  the taskIconBar
                IconeDeNotificacao.Icon = myIcon; //set the new  icon
            }
