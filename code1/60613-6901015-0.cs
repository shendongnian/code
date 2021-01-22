    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        if (Owner != null && StartPosition == FormStartPosition.Manual) {
            int offset = Owner.OwnedForms.Length * 38;  // approx. 10mm
            Point p = new Point(Owner.Left + Owner.Width / 2 - Width / 2 + offset, Owner.Top + Owner.Height / 2 - Height / 2 + offset);
            this.Location = p;
        }
    }
