    protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
    {
        e.DrawBackground();
        if (e.Index > -1)
        {
            String itemText = String.Format("{0}", this.Items.Count > 0 ? this.Items[e.Index] : this.Name);
            //Snip
            System.Windows.Forms.ControlPaint.DrawButton(e.Graphics, e.Bounds, ButtonState.Normal);
            e.Graphics.DrawString(itemText, this.Font, SystemBrushes.ControlText, e.Bounds);
        }
    }
