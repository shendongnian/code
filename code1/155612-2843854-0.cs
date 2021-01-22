      Bitmap bmp = new Bitmap(100,100);
      using (Graphics g = Graphics.FromImage(bmp))
      {
        g.CopyFromScreen(0, 0, 0, 0, new Size(100, 100));        
      }
      pictureBox1.Image = bmp;
