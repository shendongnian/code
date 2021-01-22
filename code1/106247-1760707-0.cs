    //The main thread might look something like this
    
    try{
    	var database = LoadDatabaseFromUserInput();
    	
    	//Do other stuff with database
    }
    catch(Exception ex){
    	//Since this is probably the highest layer,
    	// then we have no clue what just happened
    	Logger.Critical(ex);
    	DisplayTheIHaveNoIdeaWhatJustHappenedAndAmGoingToCrashNowMessageToTheUser(ex);
    }
    //And here is the implementation
    
    public IDatabase LoadDatabaseFromUserInput(){
    
    	IDatabase database = null;
    	userHasGivenUpAndQuit = false;
    	
    	//Do looping close to the control (in this case the user)
    	do{
    		try{
    			//Wait for user input
    			GetUserInput();
    			
    			//Check user input for validity
    			CheckConfigFile();
    			CheckDatabaseConnection();
    			
    			//This line shouldn't fail, but if it does we are
    			// going to let it bubble up to the next layer because
    			// we don't know what just happened
    			database = LoadDatabaseFromSettings();
    		}
    		catch(ConfigFileException ex){
    			Logger.Warning(ex);
    			DisplayUserFriendlyMessage(ex);
    		}
    		catch(CouldNotConnectToDatabaseException ex){
    			Logger.Warning(ex);
    			DisplayUserFriendlyMessage(ex);
    		}
    		finally{
    			//Clean up any resources here
    		}
    	}while(database != null); 
    }
