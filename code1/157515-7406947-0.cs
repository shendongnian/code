    private static void ProcessRetrievedFiles(List<string> retrievedFiles)
        {
            Console.WriteLine();
            Console.WriteLine("Processing retrieved files:");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            foreach (string filePath in retrievedFiles)
            {
                if (String.IsNullOrEmpty(filePath)) continue;
                Console.WriteLine(filePath);
                Process transformProcess = new Process();
                string baseOutputFilePath = Path.Combine(ExportDirectory, Path.GetFileNameWithoutExtension(filePath));
                transformProcess.StartInfo.FileName = TransformerExecutablePath;
                transformProcess.StartInfo.Arguments = string.Format(
                    "-i:\"{0}\" -x:\"{1}\" -o:\"{2}.final.xml\"",
                    filePath,
                    string.Empty,
                    baseOutputFilePath);
                transformProcess.StartInfo.UseShellExecute = false;
                transformProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                transformProcess.StartInfo.RedirectStandardError = true;
                transformProcess.StartInfo.RedirectStandardOutput = true;
                transformProcess.StartInfo.RedirectStandardInput = true;
                transformProcess.EnableRaisingEvents = true;
                //attach the error/output recievers for logging purposes
                transformProcess.ErrorDataReceived += TransformProcessErrorDataReceived;
                transformProcess.OutputDataReceived += TransformProcessOutputDataReceived;
                ProcessBridgeFileOutputWriter = new StreamWriter(
                        baseOutputFilePath + ".log",
                        false);
                ProcessBridgeFileOutputWriter.AutoFlush = true;
                
                transformProcess.Start();
                transformProcess.BeginOutputReadLine();
                transformProcess.BeginErrorReadLine();
                //the exe asks the user to press a key when they are done...
                transformProcess.StandardInput.Write(Environment.NewLine);
                transformProcess.StandardInput.Flush();
                //because we are not doing this asynchronously due to output writer
                //complexities we don't want to deal with at this point, we need to 
                //wait for the process to complete
                transformProcess.WaitForExit();
                ProcessBridgeFileOutputWriter.Close();
                ProcessBridgeFileOutputWriter.Dispose();
                //detach the error/output recievers
                transformProcess.ErrorDataReceived -= TransformProcessErrorDataReceived;
                transformProcess.OutputDataReceived -= TransformProcessOutputDataReceived;
            }
        }
        static void TransformProcessOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                ProcessBridgeFileOutputWriter.WriteLine(e.Data);
            }
        }
        static void TransformProcessErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                ProcessBridgeFileOutputWriter.WriteLine(string.Format("ERROR: {0}", e.Data));
            }
        }
