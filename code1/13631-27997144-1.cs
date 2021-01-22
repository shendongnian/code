     string zipfile = @"E:\Folderx\NPPES.zip";
     string folder = @"E:\TargetFolderx";
   
     ExtractFile(zipfile,folder);
    public void ExtractFile(string source, string destination)
            {
                // If the directory doesn't exist, create it.
                if (!Directory.Exists(destination))
                    Directory.CreateDirectory(destination);
    
                //string zPath = ConfigurationManager.AppSettings["FileExtactorEXE"];
              //  string zPath = Properties.Settings.Default.FileExtactorEXE; ;
    
                string zPath=@"C:\Program Files\7-Zip\7zG.exe";
    
                try
                {
                    ProcessStartInfo pro = new ProcessStartInfo();
                    pro.WindowStyle = ProcessWindowStyle.Hidden;
                    pro.FileName = zPath;
                    pro.Arguments = "x \"" + source + "\" -o" + destination;
                    Process x = Process.Start(pro);
                    x.WaitForExit();
                }
                catch (System.Exception Ex) { }
            }
