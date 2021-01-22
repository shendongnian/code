    for (int i = 0; i < 200; i++)
    {
        
        Control control = new CheckBox();
        
        control.Location = new Point(20, 22); 
        i += control.Size.Width + 5;
        
        list.Add(control);
    }
