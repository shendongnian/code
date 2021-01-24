    InputSimulator cmd = new InputSimulator();
            
            if (e.KeyPressEvent.KeyPressState.Equals("BREAK"))
            {
                cpt = 0;
                Console.WriteLine(e.KeyPressEvent.Name);
                //Check the Device name first !!!!
                //if(e.KeyPressEvent.Name.Contains(Settings.Default.DeviceName) || Settings.Default.DeviceName.Contains(e.KeyPressEvent.Name)) { }
                String ActiveProcess = ActiveApp.getActiveProccess();
              switch (ActiveProcess)
                {
                    case "chrome":
                        if(API.getChromeUrl().Contains("facebook") || API.getChromeUrl().Contains("messenger"))
                        {
                            switch (e.KeyPressEvent.VKeyName)
                            {
                                case "NUMPAD0":
                                    cmd.Keyboard.TextEntry(FBEmo.numpad0);
                                    break;
