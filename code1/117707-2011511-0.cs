    if(HasValidRegistryKeys()) //Check if initial settings are already there
    {
        Runnable=true;
    }
    else
    {
    //Not installed, lets setup app settings
    //Assume that the application is running for the first time.
    try
    {
        SetupRegistry(); //Set installation=done
        SetupDatabase();
        //Setup more things.
        Runnable=true;
    }
    catch()
    {Runnable=false;}
    
    }
    
    //Run the app
    if(Runnable)
    {
        RunApp();
    }
    else
    {
        MessageBox.Show("Some error");
    }
