        private Bitmap CapturedImage(Bitmap bm, int x, int y)
        {
            Bitmap b = new Bitmap(XX, YY);
            Graphics g = Graphics.FromImage(b);
            g.CopyFromScreen(x, y, 0, 0, new Size(XX, YY));
            
            //option B - If you DO need to keep a copy of the image use PNG and delete the old image
            /*
            try
            {
                if(System.IO.File.Exists(@"C:\Applications\CaptureImage.jpg"))
                {
                    System.IO.File.Delete(@"C:\Applications\CaptureImage.jpg");
                }
                b.Save(@"C:\Applications\CaptureImage.jpg", ImageFormat.Png);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("There was a problem trying to save the image, is the file in open in another program?\r\nError:\r\n\r\n" + ex.Message);
            }
            */
            //option C - If you DO need to keep a copy of the image AND keep all copies of all images when you click the button use PNG and generate unique filename
            /*
            int id = 0;
            while(System.IO.File.Exists(@"C:\Applications\CaptureImage" + id.ToString().PadLeft('0',4) + ".jpg"))
            {
                //increment the id until a unique file name is found
                id++;
            }
            b.Save(@"C:\Applications\CaptureImage" + id.ToString().PadLeft('0',4) + ".jpg", ImageFormat.Png);
            */
            
            
            int black_pixels = CountPixels(b, Color.FromArgb(255, 0, 0, 0));
            textBox3.Text = black_pixels + " black pixels";
            return b;
        }
