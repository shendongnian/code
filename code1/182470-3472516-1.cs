    static void DoWork(object sender, DoWorkEventArgs e)
    {
    	e.Result = "4";
    }
    
    static void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    	if (e.Error == null)
    	{
    		string a = (string)e.Result;
    		Console.WriteLine(a);
    	}
    	else
    	{
    		Console.WriteLine(e.Error.Message);
    	}
    }
