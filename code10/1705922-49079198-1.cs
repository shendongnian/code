    Bitmap AdminPage_Full;
    Bitmap AdminPage_ClientArea;
        AdminPage_Full = PrintForm(true);
        AdminPage_ClientArea = PrintForm(false);
        //Test it
        this.pictureBox1.Image = (Bitmap)AdminPage_Full.Clone();
        this.pictureBox2.Image = (Bitmap)AdminPage_ClientArea.Clone();
        private Bitmap PrintForm(bool TheWholeForm)
        {
            using (Bitmap bitmap = new Bitmap(this.Bounds.Width, this.Bounds.Height)) {
                using (Graphics graphics = Graphics.FromImage(bitmap)) {
                    if (TheWholeForm) {
                        graphics.CopyFromScreen(this.Bounds.Location, new Point(0, 0), this.Bounds.Size);
                    } else {
                        graphics.CopyFromScreen(this.PointToScreen(this.ClientRectangle.Location),
                                                new Point(0, 0), this.ClientRectangle.Size);
                    }
                    graphics.DrawImage(bitmap, new Point(0, 0));
                    return (Bitmap)bitmap.Clone();
                };
            };
        }
