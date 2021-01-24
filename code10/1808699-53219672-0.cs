    private float HorizontalTileHeightMultiplier = 2;
    private void menuItem1_Click(object sender, EventArgs e)
    {
        TileHorizontal()
    }
    private void TileHorizontal()
    {
		int OpenedForms = Application.OpenForms().Count - 1;
		if (OpenedForms < 2) return;
        int StartLocation = 0;
        int ChildrenHeight = 
            (int)((this.ClientSize.Height / OpenedForms) * HorizontalTileHeightMultiplier);
        foreach (Form child in this.MdiChildren.OrderBy(f => f.Name))
        {
            child.Size = new Size(this.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 4, ChildrenHeight);
            child.Location = new Point(0, StartLocation);
            StartLocation += ChildrenHeight;
        }
    }
