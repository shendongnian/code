    HardwareButtonEnter.Press += delegate{ userInput = eventParameters.userInput; 
        UserInputReceived = true;}; //This is really hardware API specific code, only the boolean is important
    
    //start an async thread/process for reading master terminal input.
    while(1 = 1){
       if(UserInputReceived){
          ProcessUserInput().
       }elseif(masterTerminalDataReceived){
          ProcessMasterTerminalData().
       }
    }
