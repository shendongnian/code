            Process sortProcess;
            sortProcess = new Process();
            sortProcess.StartInfo.FileName = "Sort.exe";
            // Set UseShellExecute to false for redirection.
            sortProcess.StartInfo.UseShellExecute = false;
            // Redirect the standard output of the sort command.  
            // This stream is read asynchronously using an event handler.
            sortProcess.StartInfo.RedirectStandardOutput = true;
            sortOutput = new StringBuilder("");
            // Set our event handler to asynchronously read the sort output.
            sortProcess.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler);
            // Redirect standard input as well.  This stream
            // is used synchronously.
            sortProcess.StartInfo.RedirectStandardInput = true;
            sortProcess.Start();
            // Use a stream writer to synchronously write the sort input.
            StreamWriter sortStreamWriter = sortProcess.StandardInput;
            // Start the asynchronous read of the sort output stream.
            sortProcess.BeginOutputReadLine();
            Console.WriteLine("Ready to sort up to 50 lines of text");
            String inputText;
            int numInputLines = 0;
            do 
            {
                Console.WriteLine("Enter a text line (or press the Enter key to stop):");
                inputText = Console.ReadLine();
                if (!String.IsNullOrEmpty(inputText))
                {
                    numInputLines ++;
                    sortStreamWriter.WriteLine(inputText);
                }
            }
