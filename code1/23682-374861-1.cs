    private void timer1_Tick(object sender, EventArgs e)
    {
        if (listView1.Items[0] == null)
        {
            return;
        }
    
        Rectangle bounds = listView1.Items[0].Bounds;
    
        if (bounds != _firstItemBounds)
        {
            _firstItemBounds = bounds;
    
            // Any scroll logic here
            // ...
        }
    }
