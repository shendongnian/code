    bool debug = false;
    
    ConsoleKeyInfo keyinfo = Console.ReadKey();
    
    if (keyinfo.Key == ConsoleKey.F10)
    {
        debug = !debug;
        if(debug)
        {
           //Your code here if debug = true
        }
        else
        {
           //Your code here if debug = false
        }
    }
    else
    {
      
        //Your code here if key press other than F10
    }
