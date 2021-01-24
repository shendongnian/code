    private void OutputReceivedHandler(object sender, DataReceivedEventArgs e)
    {
        Console.WriteLine(e.Data);
    }
    
    private void ErrorReceivedHandler(object sender, ErrorReceivedEventArgs e)
    {
        Console.WriteLine(e.Data);
    }
