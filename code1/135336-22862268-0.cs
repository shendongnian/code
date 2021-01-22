    private void ds_SplitContainer_Paint(object sender, PaintEventArgs e)
    {
        SplitContainer l_SplitContainer = sender as SplitContainer;
            
        if (l_SplitContainer != null)
        {
            Rectangle ll_ShrinkedSplitterRectangle = l_SplitContainer.SplitterRectangle;
            ll_ShrinkedSplitterRectangle.Offset(0, 2);
            ll_ShrinkedSplitterRectangle.Height = ll_ShrinkedSplitterRectangle.Height - 2;
            e.Graphics.FillRectangle(Brushes.Silver, ll_ShrinkedSplitterRectangle);
        }
    }
