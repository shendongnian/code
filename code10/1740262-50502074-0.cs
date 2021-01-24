    public class YourClass
    {
    
    TimeSpan tSpan;
    
    
    public void PerformOp()
    {
    tSpan=new TimeSpan();
    for (int i = 0; i < 50; i++)
     {
        DoSomethingAsync (i);
     }
    
    }
    
    private async static void DoSomethingAsync (int i)
    {
    Stopwatch stp = new StopWatch();
    stp.Start();
    //your Operation here
    stp.Stop();
    tSpan+=stp.Elapsed;//not the exact systax or usage but you get the idea 
    }
    
    }
