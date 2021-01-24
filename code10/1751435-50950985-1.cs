    // this runs on a background pool thread
    void DoWork(object sender, args)
    {
        var worker = sender as Backgroundworker;
        var Numbers = args.Argument as IEnumerable<SomeThing>;
        int percentage = 0;    
        foreach (var number in Numbers)
        {
            //Send a Message here
            worker.ReportProgress(percentage, number);
            // other processing on number, just don't use the UI
        }
    }
