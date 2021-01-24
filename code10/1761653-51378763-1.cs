    public void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        //enabledCommands is an array of strings (or whatever can store Atext.Text and the others)
        if(enabledCommands.Contains(e.Result.Text){ //First check if whatever command you received is enabled
          if(e.Result.Text == Atext.Text) //then check what command it is and execute it
          {
             PressKey(0x1E);
          }
        }
    }
