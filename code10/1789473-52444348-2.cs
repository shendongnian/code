    public async Task DoStuff(IProgress<double> progress = null)
    {
         for(int i = 0; i < 100; ++i)
         {
             await Task.Delay(500);
             progress?.Report((double)(i +1) / 100);
         }
    }
    // somewhere else in your code
    public void StartProgress(){
        var progress = new Progress(p => Console.WriteLine($"Progress {p}"));
        DoStuff(progress);  
    }
