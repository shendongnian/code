        public static Color GetPixelColor(Visual visual, Point pt)
        {
            Point ptDpi = getScreenDPI(visual);
            Size srcSize = VisualTreeHelper.GetDescendantBounds(visual).Size;
            //Viewbox uses values between 0 & 1 so normalize the Rect with respect to the visual's Height & Width
            Rect percentSrcRec = new Rect(pt.X / srcSize.Width, pt.Y / srcSize.Height,  
                                          1 / srcSize.Width, 1 / srcSize.Height);
            //var bmpOut = new RenderTargetBitmap(1, 1, 96d, 96d, PixelFormats.Pbgra32); //assumes 96 dpi
            var bmpOut = new RenderTargetBitmap((int)(ptDpi.X / 96d),
                                                (int)(ptDpi.Y / 96d),
                                                ptDpi.X, ptDpi.Y, PixelFormats.Default); //generalized for monitors with different dpi
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                dc.DrawRectangle(new VisualBrush { Visual = visual, Viewbox = percentSrcRec },
                                 null, //no Pen
                                 new Rect(0, 0, 1d, 1d) );
            }
            bmpOut.Render(dv);
            var bytes = new byte[4];
            int iStride = 4; // = 4 * bmpOut.Width (for 32 bit graphics with 4 bytes per pixel -- 4 * 8 bits per byte = 32)
            bmpOut.CopyPixels(bytes, iStride, 0); 
            return Color.FromArgb(bytes[0], bytes[1], bytes[2], bytes[3]);
        }
