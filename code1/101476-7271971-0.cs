            QRCodeWriter writer = new QRCodeWriter();
            com.google.zxing.common.ByteMatrix matrix;
            int size = 180;
            matrix = writer.encode("MECARD:N:Owen,Sean;ADR:76 9th Avenue, 4th Floor, New York, NY 10011;TEL:+12125551212;EMAIL:srowen@example.com;; ", BarcodeFormat.QR_CODE, size, size, null);
            Bitmap img = new Bitmap(size, size);
            Color Color = Color.FromArgb(0, 0, 0);
            for (int y = 0; y < matrix.Height; ++y)
            {
                for (int x = 0; x < matrix.Width; ++x)
                {
                    Color pixelColor = img.GetPixel(x, y);
                    //Find the colour of the dot
                    if (matrix.get_Renamed(x, y) == -1)
                    {
                        img.SetPixel(x, y, Color.White );
                    }
                    else
                    {
                        img.SetPixel(x, y, Color.Black);
                    }
                }
            }
            img.Save(@"c:\test.bmp",ImageFormat.Bmp);
