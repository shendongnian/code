    public void ShowScrollBars(Orientation orientation,bool isVisible)
    {
        if (orientation == Orientation.Vertical)
        {
            vScrollBar.Visible = isVisible;
        }
        else
        {
            hScrollBar.Visible = isVisible;
        }
    }
