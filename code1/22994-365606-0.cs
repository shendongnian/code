                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = fileName;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.UseShellExecute = false;
            
                proc.Start();
                proc.WaitForExit();
                output1 = proc.StandardError.ReadToEnd();
                proc.WaitForExit();
                output2 = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit();
