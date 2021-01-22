        // not sure if all this flags are needed
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.ErrorDialog = false;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.EnableRaisingEvents = true;
        process.OutputDataReceived += process_OutputDataReceived;
        process.ErrorDataReceived += process_OutputDataReceived;
        process.Exited += process_Exited;
        process.Start();
        void process_Exited(object sender, System.EventArgs e)
        {
            // do something when process terminates;
        }
        void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // a line is writen to the out stream. you can use it like:
            string s = e.Data;
        }
        void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            // a line is writen to the out stream. you can use it like:
            string s = e.Data;
        }
