    int[,] controls = new int[10, 10];
    
    for (int x = 0; x < 10; x++)
    {
        for (int y = 0; y < 10; y++)
        {
            // Create new control and initialize it by whatever means
            MyCustControl control = new MyCustControl();
     
            // Add new control to the container       
            Children.Add(control);
            
            // Store control reference in the array
            controls[x, y] = control;
        }
    }
