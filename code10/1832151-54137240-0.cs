     class Dism
        {
            public async Task Com(String command, string logName)
            {
               Console.WriteLine("received " + command);
               System.Diagnostics.Process process = new System.Diagnostics.Process();
               System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
               startInfo.UseShellExecute = true;
               startInfo.CreateNoWindow = false;
               startInfo.RedirectStandardOutput = true;
               startInfo.UseShellExecute = false;
               startInfo.FileName = "Dism.exe";
               startInfo.Arguments = command;
            // startInfo.Arguments = command;
               process.StartInfo = startInfo;
               Task t = Task.Run(() => process.Start());
               t.Wait();
               string output = process.StandardOutput.ReadToEnd();
               Console.BackgroundColor = ConsoleColor.Black;
               if (output.Contains("0/1"))
               {
                   Console.ForegroundColor = ConsoleColor.Yellow;
                   installerOptimized.install.success = false;
               }
               else
               {
                   Console.ForegroundColor = ConsoleColor.Green;
                   installerOptimized.install.success = true;
               }
               Console.WriteLine(output);
               string success = installerOptimized.install.success ? "successful" : "unsuccessful";
               System.IO.File.WriteAllLines("Logs/" + logName + "_" + success + ".txt", output.Split('\n'));
               process.WaitForExit();
           }
       }
