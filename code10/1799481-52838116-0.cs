    class BorderedPhoto : Photo
    {
        Photo photo;
        Color color;
        bool mouse_click = false;
        public BorderedPhoto(Photo p, Color c)
        {
            photo = p;
            color = c;
            this.MouseClick += new MouseEventHandler(mouse);
        }
        public void mouse(object sender, MouseEventArgs e) // a method which will handle the mouse clicking
        {
            if (e.Button == MouseButtons.Left)
            {
                mouse_click = true;
                Invalidate(); // ADD INVALIDATE HERE
            }
        }
        public override void Drawer(Object source, PaintEventArgs e)
        {
            photo.Drawer(source, e);
            if (mouse_click == true) // if mouse was clicked, then draw the border
                e.Graphics.DrawRectangle(new Pen(color, 10), 25, 15, 215, 225);
        }
    }
