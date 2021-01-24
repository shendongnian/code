    public void DynamicButtons()
    {
      for(int i = 0; i < 3; i++)
      {
      	var copy = i;
      	
        Button newButton = new Button 
        { 
        	Command = new Command(() => 
        	{ 
        		SomeFunction(copy); 
    		}), 
        	Text = i.ToString() 
        };
      }
    }
