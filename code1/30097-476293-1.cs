    void pnlViewport_Paint(object sender, PaintEventArgs e) {
        if ( e.ClipRectange.Width < 1 || e.ClipRectangle.Height < 1 ) return;
        Bitmap b = new Bitmap(e.Graphics, e.ClipRectangle.Width, e.ClipRectangle.Height)
        // ...
    }
