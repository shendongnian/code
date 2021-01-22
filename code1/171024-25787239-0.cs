         public void ExtractFile(string source, string destination)
            {
                // If the directory doesn't exist, create it.
                if (!Directory.Exists(destination))
                    Directory.CreateDirectory(destination);
    
                string zPath = @"C:\Program Files\7-Zip\7zG.exe";
    // change the path and give yours 
                try
                {
                    ProcessStartInfo pro = new ProcessStartInfo();
                    pro.WindowStyle = ProcessWindowStyle.Hidden;
                    pro.FileName = zPath;
                    pro.Arguments = "x \"" + source + "\" -o" + destination;
                    Process x = Process.Start(pro);
                    x.WaitForExit();
                }
                catch (System.Exception Ex) {
                  //DO logic here 
                  }
            }
