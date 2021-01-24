    public void Start_Click(object sender, EventArgs args)
    {
        //Make sure both the CTS and block are created before setting the fields  
        var cts=new CancellationTokenSource(60000); //Timeout in 1 minute
        var token=cts.Token;
        var options = new ExecutionDataflowBlockOptions
        {
            MaxDegreeOfParallelism = 20,
            CancellationToken=token
         };
       var block=new ActionBlock<string>(file => SomeSlowFileProcessing(file,token), 
                                         options);
       //Once preparation is over ...
       _cts=cts;
       _block=block;
       //Start posting files
      ...
       
    }
    public async void Cancel_Click(object sender, EventArgs args)
    {
       lblStatus.Text = "Cancelling";
        _cts.Cancel();
       
       try
       {
           await _block.Completion;           
       }
       lblStatus.Text = "Cancelled!";
    }
