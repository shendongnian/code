    Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
    Graphics gr = Graphics.FromImage(bmp);
    gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);
    pictureBox1.Image = bmp;
    bmp.Save("img.png",System.Drawing.Imaging.ImageFormat.Png);
