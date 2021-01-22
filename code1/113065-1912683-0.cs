                files = System.IO.Directory.GetFiles(@"C:\PicFolder");
                for (string file in files)
                {
                Bitmap tempBmp = new Bitmap(file);
                Bitmap bmp = new Bitmap(tempBmp, 807, 605);
    
                bmp.Save(
                @"C:\NewPicFolder\Pic" + count + ".jpg",
                System.Drawing.Imaging.ImageFormat.Jpeg);
                count++;
                }
