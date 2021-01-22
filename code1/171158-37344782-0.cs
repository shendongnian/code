    protected override void OnSelectionChanged(EventArgs e)
    {
        base.OnSelectionChanged(e);
        if (SelectedCells.Count > 1)
        {
            // leave edit mode
            Parent?.Focus();
        }
    }
