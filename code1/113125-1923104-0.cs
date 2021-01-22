    int VO = 0; // I think that this was protection for when a load of items are added at the beginning. Maybe you can do fine without it.
    private void HomeList_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
    	int v = (int)e.VerticalOffset;
    	if (HomeList.Items.Count > 0 && v != VO) // Maybe you can do fine without VO.
    	{
    		for (int i = 0; i < e.ViewportHeight; i++)
    		{
    			// Add 1 millisecond to the item's time here
    		}
    		VO = v; // Maybe you can do fine without VO.
    	}
    }
