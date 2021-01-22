    this.Activated += new System.EventHandler(this.HideOwner);
    private void HideOwner(object sender, EventArgs e)
    {
        if (this.Owner != null) this.Owner.Hide();
    }
    protected override void Dispose(bool disposing)
    {
        if (this.Owner != null) this.Owner.Show();
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
