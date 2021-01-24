    // option A: disable all buttons except button at index 2 
    for (int i = 0; i < buttons.Count; ++i)
    {
        if (i == 2)
        {
            continue;
        }
    
        buttons[i].IsEnabled = false;
    }
    
    // option b: disable all buttons except button with name 'button3'
    foreach (var button in buttons)
    {
        if (button.Name == "button3")
        {
            continue;
        }
    
        button.IsEnabled = false;
    }
