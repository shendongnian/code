        using(Image a = Image.FromFile("1.png"))
        using(Image b = Image.FromFile("2.png"))
        using (var bitmap = new Bitmap(200, 200))
        using (var canvas = Graphics.FromImage(bitmap))
        {
            Rectangle r = new Rectangle(new Point(0, 0), new Size(200, 200));
            ColorMatrix cmxPic = new ColorMatrix();
                cmxPic.Matrix33 = 1.0f;
                ImageAttributes iaPic = new ImageAttributes();
                iaPic.SetColorMatrix(cmxPic, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                ColorMatrix cmxPic2 = new ColorMatrix();
                cmxPic2.Matrix33 = 0.5f;
                ImageAttributes iaPic2 = new ImageAttributes();
                iaPic2.SetColorMatrix(cmxPic2, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                
                canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                canvas.DrawImage(a, r, 0, 0, 200, 200, GraphicsUnit.Pixel, iaPic);
                canvas.DrawImage(b, r, 0, 0, 200, 200, GraphicsUnit.Pixel, iaPic2);
            canvas.Save();
            
            bitmap.Save("output.png", ImageFormat.Png);
        }
