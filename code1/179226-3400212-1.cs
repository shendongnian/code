    class LaunchJava
    {
   
        private static Process myProcessProcess;
        private static StreamWriter myProcessStandardInput;
        private static Thread thist = Thread.CurrentThread;
        public static void DoJava()
        {
            // Initialize the process and its StartInfo properties.
            // The sort command is a console application that
            // reads and sorts text input.
            myProcess= new Process();
            myProcess.StartInfo.Arguments = "-jar selenium-server.jar";
            myProcess.StartInfo.FileName = @"C:\Documents and Settings\cnguyen\java.exe";
            // Set UseShellExecute to false for redirection.
            myProcess.StartInfo.UseShellExecute = false;
            // Redirect the standard output of the sort command.  
            // This stream is read asynchronously using an event handler.
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcessOutput = new StringBuilder("");
            // Set our event handler to asynchronously read the sort output.
            myProcess.OutputDataReceived += new DataReceivedEventHandler(myProcessOutputHandler);
            // Redirect standard input as well.  This stream
            // is used synchronously.
            myProcess.StartInfo.RedirectStandardInput = true;
            Console.WriteLine("Start.");
            // Start the process.
            myProcess.Start();
            
            // Use a stream writer to synchronously write the sort input.
            myProcessStandardInput = myProcess.StandardInput;
            // Start the asynchronous read of the sort output stream.
            myProcess.BeginOutputReadLine();
         
           // Wait for the process to end on its own.
           // as an alternative issue some kind of quit command in myProcessOutputHandler
           myProcess.WaitForExit();
            // End the input stream to the sort command.
           myProcessInput.Close();
            myProcessProcess.Close();
        }
        private static void myProcessOutputHandler(object sendingProcess, DataReceivedEventArgs Output)
        {
            // do interactive work here if needed...
            if (!String.IsNullOrEmpty(Output.Data))
            { myProcess.StandardInput.BaseStream.Write(bytee,0,bytee.GetLength);
 
            }
        }
