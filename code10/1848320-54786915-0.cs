    process.EnableRaisingEvents = true; 
    process.OutputDataReceived += process_Output;
    process.ErrorDataReceived += process_Error;
    void process_Output(object sender, DataReceivedEventArgs e)
    {
        //e.Data would contain a line
        var outputLine = e.Data;
    }
    void process_Error(object sender, DataReceivedEventArgs e)
    {
        var errorLine = e.Data;
    }
