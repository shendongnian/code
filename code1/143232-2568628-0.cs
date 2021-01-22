     try
        {
            commandBar = Application.CommandBars["mytoolbar"];
        }
        catch (ArgumentException e)
        {
    
        }
    
        if (commandBar == null)
        {
            commandBar = Application.CommandBars.Add("mytoolbar ", 1, missing, true);
        }
