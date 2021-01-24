    public ZXing.Result Result { get; set; }
    public bool IsAnalyzing { get;set }
    public Command ScanResultCommand
    {
       get
        {
           return new Command(() =>
            {
                   
              Device.BeginInvokeOnMainThread(async () =>
                {
                  IsAnalyzing = false;
                  Console.WriteLine(Result.Text);
                  //...
                 });
                });
         }
    }
   
