        string myConnString ="";
        if(ThisIsThat("A"))
        {
            myConnString = 
                                   rootWebConfig.ConnectionStrings.ConnectionStrings["NorthwindConnectionString"];
        }
        else if(ThisIsThat("B"))
        {        
            myConnString =
                                    rootWebConfig.ConnectionStrings.ConnectionStrings["BestDBConnectionString"]
        }
    
        { else // Can go on}
