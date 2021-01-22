    private void Collection1_SelectionChanged (object sender, eventargs e)
    {
    	Collection2.SelectionChanged -= Collection2_SelectionChanged; //drop event handler
    	//make changes...
    	Collection2.SelectionChanged += Collection2_SelectionChanged; //add event handler
    }
