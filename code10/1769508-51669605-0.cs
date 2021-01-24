    List<Label> labels;
    
    private void labelCreate() 
    {
    	labels = new List<Label>();	
    	for(int i = 0; i < 100; i++)
    	{
    		labels.Add(new Label());
    	}	
    }
    
    private void labelTextChange()
    {	
        // use the index or search for the name of the label
    	labels[42].Text = "Hello World!";
    }
