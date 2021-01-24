    private void RunProc()
    {
    Process.Start("exeName");
    }
    
    
    public async Task StartProcessAsync()
    {
    var result= await Task.Run(()=>RunProc());
    //optional
    Task.Delay(new TimeSpan.FromSeconds(5));
    }
