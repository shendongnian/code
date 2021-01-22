    SortedDictionary<string, Button> buttons 
                     = new SortedDictionary<string, Button>();
    buttons.Add(btn1.Name, btn1);
    buttons.Add(btn2.Name, btn2);
    
    foreach (string name in buttons.Keys)
    {
      Button b = buttons[name];
      // iterates in name order
    }
