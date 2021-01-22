                Bitmap bm = (Bitmap)System.Drawing.Image.FromFile("TifFilePath.tif", true);
                Bitmap tmp = new Bitmap(bm.Width, bm.Height);
                Graphics grPhoto = Graphics.FromImage(tmp);
                grPhoto.DrawImage(bm, new Rectangle(0, 0, tmp.Width, tmp.Height), 0, 0, tmp.Width, tmp.Height, GraphicsUnit.Pixel);
                bm.Save("JPGFilePath.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
