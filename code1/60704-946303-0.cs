    private void panel1_Paint(object sender, PaintEventArgs e) {
       Control c = sender as Control;
       using (Font f = new Font("Tahoma", 5)) {
          e.Graphics.DrawString(c.Tag.ToString(), f, Brushes.White, new PointF(1, 1));
       }
    }
