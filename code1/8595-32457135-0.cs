                Process proc = new Process();
                proc.StartInfo.FileName = batchFile;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;      
                proc.Start();
                StreamWriter streamWriter = proc.StandardInput;
                StreamReader outputReader = proc.StandardOutput;
                StreamReader errorReader = proc.StandardError;
                while (!outputReader.EndOfStream)
                {
                    string text = outputReader.ReadLine();                    
                    streamWriter.WriteLine(text);
                }
                while (!errorReader.EndOfStream)
                {                   
                    string text = errorReader.ReadLine();
                    streamWriter.WriteLine(text);
                }
                streamWriter.Close();
                proc.WaitForExit();
