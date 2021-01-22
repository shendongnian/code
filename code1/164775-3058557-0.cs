    static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
    {
    	Console.WriteLine("Control+C hit. Shutting down.");		
    	Process.GetCurrentProcess().Kill();
    }
