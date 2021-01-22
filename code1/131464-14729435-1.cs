    // This is in a user control where the datagrid is inside (Top docked)
    protected override void OnResize(EventArgs e)
    {
        if (AutoSize)
        {
            var height = this.GetDataGridViewHeight(this.dataBoxGridView);
            this.dataBoxGridView.Height = height;
            this.Height = height +this.Padding.Top + this.Padding.Bottom;
        }
    }
