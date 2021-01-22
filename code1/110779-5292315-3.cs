        void Global_Histogramm(WpfImage.MyToolkit.WriteableBitmapProxy src)
        {
            int SrcX = src.PixelWidth;
            int SrcY = src.PixelHeight;
            double[] HR = new double[256];
            double[] HG = new double[256];
            double[] HB = new double[256];
            double[] DR = new double[256];
            double[] DG = new double[256];
            double[] DB = new double[256];
            uint i, x, y;
            //  wyzeruj tablice
            for (i = 0; i < 256; i++) HB[i] = HG[i] = HR[i] = 0;
            //  wypelnij histogramy R G B
            for (y = 0; y < SrcY; y++)
                for (x = 0; x < SrcX; x++)
                {
                    var color = src.GetPixel(x, y);
                    HB[color.B]++;
                    HG[color.G]++;
                    HR[color.R]++;
                };
            // oblicz histogramy znormalizowane i przygotuj dystrybuanty
            int ilosc_punktow = SrcX * SrcY;
            double sumaR = 0, sumaG = 0, sumaB = 0;
            for (i = 0; i < 256; i++)
            {
                DB[i] = sumaB + HB[i] / ilosc_punktow;
                DG[i] = sumaG + HG[i] / ilosc_punktow;
                DR[i] = sumaR + HR[i] / ilosc_punktow;
                sumaB = DB[i];
                sumaG = DG[i];
                sumaR = DR[i];
            };
            Dispatcher.BeginInvoke(DispatcherPriority.Background,
                  (SendOrPostCallback)delegate { progressBar1.Maximum = SrcY - 1; }, null);
 
            
            // aktualizuj bitmape
            for (y = 0; y < SrcY; y++)
            {
                for (x = 0; x < SrcX; x++)
                {
                    var stmp = src.GetPixel(x, y);
                    var val = new WpfImage.MyToolkit.RGBColor()
                    {
                        B = (byte)(DB[stmp.B] * 255),
                        G = (byte)(DG[stmp.G] * 255),
                        R = (byte)(DR[stmp.R] * 255)
                    };
                    src.SetPixel(x, y, val);                    
                };
                Dispatcher.BeginInvoke(DispatcherPriority.Background,
                      (SendOrPostCallback)delegate { progressBar1.Value = y; }, null);
                
            }
        }
