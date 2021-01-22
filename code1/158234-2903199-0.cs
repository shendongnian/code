            Bitmap lol = new Bitmap(100, 100); ;
            GraphicsUnit units = GraphicsUnit.Pixel;
            System.Drawing.Imaging.ImageAttributes imageAttr = new System.Drawing.Imaging.ImageAttributes();
            Graphics gx = Graphics.FromImage(lol);
            int width = testing.Width / 3;
            int height = testing.Height / 3;
            Rectangle destrect1 = new Rectangle(0, 0, width, height);
               //1.1.jpg//
            gx.DrawImage(testing, destrect1, 0, 0, width, height, units, imageAttr);
            pictureBox2.Image = lol;
            lol.Save(@"Pictures\\hahaha.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
           // pictureBox2.Image = gx.(lol); 
            
        }
