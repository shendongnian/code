    Bitmap AdminPage_Full;
    Bitmap AdminPage_ClientArea;
        AdminPage_Full = PrintForm(true);
        AdminPage_ClientArea = PrintForm(false);
        //Test it
        this.pictureBox1.Image = (Bitmap)AdminPage_Full.Clone();
        this.pictureBox2.Image = (Bitmap)AdminPage_ClientArea.Clone();
        private Bitmap PrintForm(bool TheWholeForm)
        {
            using (Bitmap bitmap = new Bitmap(this.Bounds.Width, this.Bounds.Height))
            {
                Graphics graphics = Graphics.FromImage(bitmap);
                if (TheWholeForm) {
                    graphics.CopyFromScreen(this.Bounds.Location, new Point(0, 0), this.Bounds.Size);
                } else {
                    graphics.CopyFromScreen(
                             new Point(this.PointToScreen(this.ClientRectangle.Location).X,
                                       this.PointToScreen(this.ClientRectangle.Location).Y),
                             new Point(0, 0),
                             this.ClientRectangle.Size);
                }
                graphics.DrawImage(bitmap, new Point(0, 0));
                graphics.Dispose();
                return (Bitmap)bitmap.Clone();
            };
        }
