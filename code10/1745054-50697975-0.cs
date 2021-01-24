    private static void Main(string[] args)
            {
                var inputFile = @"C:\Temp\test.mp4";
                var outputFile = @"C:\Temp\test.mp3";
    
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        Arguments = "-i - -f mp3 -",
                        FileName = "ffmpeg.exe"
                    },
                    EnableRaisingEvents = true
                };
    
                process.ErrorDataReceived += (sender, eventArgs) =>
                {
                    Console.WriteLine(eventArgs.Data);
                };
    
                process.Start();
                process.BeginErrorReadLine();
    
                var inputTask = Task.Run(() =>
                {
                    using (var input = new FileStream(inputFile, FileMode.Open))
                    {
                        input.CopyTo(process.StandardInput.BaseStream);
                        process.StandardInput.Close();
                    }
                });
    
                var outputTask = Task.Run(() =>
                {
                    using (var output = new FileStream(outputFile, FileMode.Create))
                    {
                        process.StandardOutput.BaseStream.CopyTo(output);
                    }
                });
    
    
                Task.WaitAll(inputTask, outputTask);
    
                process.WaitForExit(); 
                    
                Console.WriteLine("done");
                Console.ReadLine();
            }
