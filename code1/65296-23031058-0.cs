          string path = (Assembly.GetEntryAssembly().Location + "");
          path = path.Replace("name space", "filename.--");
         
          // [WindowsFormsApplication4] is name space 
          //you should copy your "mysound.wav" into Depug file 
      
             //example::
           string path_sound  = (Assembly.GetEntryAssembly().Location + "");
          path_sound  = path_sound.Replace("WindowsFormsApplication4.exe", "mysound.wav");
          SoundPlayer player1 = new SoundPlayer(path_sound);
          player1.Play();
