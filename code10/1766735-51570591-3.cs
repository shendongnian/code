    // create some buttons for simulation purposes, give them a name and put them into a list
    var buttons = new List<Button>();    
    for (int i = 0; i < 10; ++i)
    {
        var button = new Button();
        button.Name = "button" + i;
        buttons.Add(button);
    }
    
