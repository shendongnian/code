        //1. Take a screenshot
       Bitmap b1 = new Bitmap(Screen.PrimaryScreen.Bounds.Width,Screen.PrimaryScreen.Bounds.Height);
        Graphics g = Graphics.FromImage(b1);
        g.CopyFromScreen(0, 0, Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
        b1.Save("screen.bmp");
       //2. Create pixels (stars) at a custom resolution, changing constantly like stars
        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
            * Steps to use this code:
            * 1. Create new form
            * 2. Set form properties to match the settings below:
            *       AutoSize = true
            *       AutoSizeMode = GrowAndShrink
            *       MaximizeBox = false
            *       MinimizeBox = false
            *       ShowIcon = false;
            *       
            * 3. Create picture box with these properties:
            *       Dock = Fill
            * 
            */
            //<Definitions>
            Size imageSize = new Size(400, 400);
            int minimumStars = 600;
            int maximumStars = 800;
            //</Definitions>
            Random r = new Random();
            Bitmap b1 = new Bitmap(imageSize.Width, imageSize.Height);
            Graphics g = Graphics.FromImage(b1);
            g.Clear(Color.Black);
            for (int i = 0; i <r.Next(minimumStars, maximumStars); i++)
            {
                int x = r.Next(1, imageSize.Width);
                int y = r.Next(1, imageSize.Height);
                b1.SetPixel(x, y, Color.WhiteSmoke);
            }
            pictureBox1.Image = b1;
        }
