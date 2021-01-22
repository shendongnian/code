    Process myProcess = new Process();
            
            try
            {
                // Get the path that stores user documents.
                string myDocumentsPath = 
                    Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                myProcess.StartInfo.FileName = myDocumentsPath + "\\MyFile.doc"; 
                myProcess.StartInfo.Verb = "Print";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
            }
            catch (Win32Exception e)
            {
                if(e.NativeErrorCode == ERROR_FILE_NOT_FOUND)
                {
                    Console.WriteLine(e.Message + ". Check the path.");
                } 
                else if (e.NativeErrorCode == ERROR_ACCESS_DENIED)
                {
                    // Note that if your word processor might generate exceptions
                    // such as this, which are handled first.
                    Console.WriteLine(e.Message + 
                        ". You do not have permission to print this file.");
                }
            }
