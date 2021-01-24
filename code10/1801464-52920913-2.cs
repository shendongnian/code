    private void MyForm_Paint(object sender, PaintEventArgs e)
    {
        Pen pen = new Pen(Color.Red);
        foreach(Point point in track)
        {
            Rectangle rect = new Rectangle(point, new Size(1,1));
            e.Graphics.DrawRectangle(pen, rect);
        }
    }
