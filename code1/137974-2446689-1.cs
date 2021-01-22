    using(SvnClient client = /* set up a client */ ){
        EventHandler<SvnStatusEventArgs> statusHandler = new EventHandler<SvnStatusEventArgs>(HandleStatusEvent);
        client.Status(@"c:\foo\some-working-copy", statusHandler);
    }
    
    ...
    
    void HandleStatusEvent (object sender, SvnStatusEventArgs args)
    {
        switch(args.LocalContentStatus){
            case SvnStatus.Added: // Handle appropriately
                break;
        }
        // review other properties of 'args'
    }
