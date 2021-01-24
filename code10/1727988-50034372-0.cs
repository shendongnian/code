        var gAssembly = Assembly.LoadFrom(JLDBConnection.Properties.Settings.Default.DefaultString + @"\JLRetailTerminal.exe");
        Type typ = gAssembly.GetExportedTypes().Where(s => s.Name == "RetailWindow").FirstOrDefault();
        //if extend sale is set prevent multiple windows
        if (gWindow == null)
        {//show if window has never been opened
              gWindow = (Window)Activator.CreateInstance(typ);
              gWindow.Show();
        }
        else
        {//window has been opened
              var windows = Application.Current.Windows; //get all opened windows in applications                                        
              if (!windows.OfType<Window>().Contains(gWindow) || !(JLDBConnection.Properties.Settings.Default.ExtendSale == "Yes"))
              {   //if window has been closed   or not multiple sale database                                                                                
                    gWindow = (Window)Activator.CreateInstance(typ);
                    gWindow.Show();
              }
         }
