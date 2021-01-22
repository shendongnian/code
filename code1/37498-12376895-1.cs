    if((this.BackColor == Color.Transparent) && (Parent != null)) {
        Bitmap behind = new Bitmap(Parent.Width, Parent.Height);
        foreach(Control c in Parent.Controls) {
            if(c != this && c.Bounds.IntersectsWith(this.Bounds)) {
                c.DrawToBitmap(behind, c.Bounds);
            }
        }
        e.Graphics.DrawImage(behind, -Left, -Top);
        behind.Dispose();
    }
