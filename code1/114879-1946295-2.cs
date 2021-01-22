    if(!myWorksheet.ProtectContents ||
       !myWorksheet.ProtectDrawinngObjects ||
       !myWorsksheet.ProtectScenarios)
    {
        string myPassword = "...";
    
        bool protectContents = true;
        bool protectDrawingObjects = true;
        bool protectScenarios = true;
    
        bool userInterfaceOnly = true;
    
        myWorksheet.Protect(
            myPassword,
            protectDrawingObjects,
            protectContents, 
            protectScenarios,
            userInterfaceOnly,    
            Type.Missing,    
            Type.Missing,    
            Type.Missing,    
            Type.Missing,    
            Type.Missing,    
            Type.Missing,    
            Type.Missing,    
            Type.Missing,    
            Type.Missing,    
            Type.Missing,    
            Type.Missing)
