     internal static void Unzip(string sorcefile)
        {
            try
            {
                AFolderFiles.AFolderFilesDelete.DeleteFolder(TempBackupFolder); // delete old folder   
                AFolderFiles.AFolderFilesCreate.CreateIfNotExist(TempBackupFolder); // delete old folder   
               //need to Command command also to export attributes to a excel file
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; // window type
                startInfo.FileName = UnzipExe;
                startInfo.Arguments = sorcefile + " -d " + TempBackupFolder;
                process.StartInfo = startInfo;
                process.Start();
                //string result = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                process.Dispose();
                process.Close();
            }
            catch (Exception ex){ throw ex; }
        }        
