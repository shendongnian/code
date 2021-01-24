    private void _addmore_TouchUpInside(object sender, EventArgs e)
    {
        NSNotificationCenter.DefaultCenter.PostNotificationName("Cell", new NSString("Add"));
    }
    private void _remove_TouchUpInside(object sender, EventArgs e)
    {
        NSNotificationCenter.DefaultCenter.PostNotificationName("Cell", Cellindex);
    }
