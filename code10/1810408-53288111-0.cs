         Process myProcess = new Process();
         myProcess.StartInfo.FileName = "someconsoleapp.exe";
         myProcess.StartInfo.UseShellExecute = false;
         myProcess.StartInfo.RedirectStandardInput = true;
         myProcess.StartInfo.RedirectStandardOutput = true;
         myProcess.StartInfo.ErrorDialog = false;
         myProcess.Start();
         StreamWriter stdInputWriter  = myProcess.StandardInput;
         StreamReader stdOutputReader  = myProcess.StandardOutput;
         stdInputWriter.WriteLine(password);
         var op = stdOutputReader.ReadLine();
         // close this - sending EOF to the console application - hopefully well written
         // to handle this properly.
         stdInputWriter.Close();
         // Wait for the process to finish.
         myProcess.WaitForExit();
         myProcess.Close();
