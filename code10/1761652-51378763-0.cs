    public void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        //mode could be a string or an enum variable
        if(mode = "LEFT_RIGHT" && e.Result.Text == Atext.Text)
        {
          PressKey(0x1E);
         }
        else if (mode = "LEFT_RIGHT" && e.Result.Text == Dtext.Text)
        {
            PressKey(0x20);
        }else if (mode = "UP_DOWN" && e.Result.Text == Stext.Text)
        {
            PressKey(...);
        }else if(mode = "UP_DOWN" && e.Result.Text == Wtext.Text)
        {
            PressKey(....);
        }
    }
