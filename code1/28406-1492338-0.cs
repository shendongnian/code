    Button btn = new Button();
    btn.Text = "Hey!";
    Bitmap bmp = new Bitmap(btn.Width, btn.Height);
    btn.DrawToBitmap(bmp, new Rectangle(0, 0, btn.Width, btn.Height));
    PictureBox pb = new PictureBox();
    pb.Size = btn.Size;
    pb.Image = bmp;
