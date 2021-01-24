    Bitmap img= new Bitmap(100, 100);
    Point p1 = pictureBox1.Location;
    Graphics gr = Graphics.FromImage(flag);
    gr.FillEllipse(new SolidBrush(Color.Red), new Rectangle(p1.X + 40, p1.Y + 40, 20, 20));
    gr.FillEllipse(new SolidBrush(Color.Red), new Rectangle(p1.X + 40, p1.Y + 80, 20, 20));
    gr.FillEllipse(new SolidBrush(Color.Red), new Rectangle(p1.X + 80, p1.Y + 40, 20, 20));
 
    picturebox1.Image = img;
    picturebox2.Image = img;
