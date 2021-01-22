            try
            {
                //run the program again and close this one
                Process.Start(Application.StartupPath + "\\blabla.exe"); 
                //or you can use Application.ExecutablePath
                //close this one
                Process.GetCurrentProcess().Kill();
            }
            catch
            { }
