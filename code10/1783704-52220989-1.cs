    List<Button> buttons = new List<Button>();
    buttons.Add(button1);
    buttons.Add(button2);
    buttons.Add(button3);
    
    button1.Clicked += delegate {
    
    	ButtonStyle(button1);
    };
    button2.Clicked += delegate {
    
    	ButtonStyle(button2);
    };
    button3.Clicked += delegate {
    
    	ButtonStyle(button3);
    };
    
    void ButtonStyle(Button btn)
    {
    
    	foreach (var button in buttons)
    	{
    		if (button.Id == btn.Id)
    		{
    			button.BackgroundColor = Color.Blue;
    			button.CornerRadius = 1;
    			button.BorderColor = Color.Red;
    			button.TextColor = Color.White;
    		}
    		else
    		{
    			button.BackgroundColor = Color.White;
    			button.CornerRadius = 1;
    			button.BorderColor = Color.Gray;
    			button.TextColor = Color.Blue;
    		}
    	}
    }
