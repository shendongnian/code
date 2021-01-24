    private void HandleEvent(object s, OnFrameArgs args)
    {
       var bmp = args.Frame.GetCopy();
    
       Task.Run(() =>
            {
                try
                {
                   AnotherObject.CostlyOperationsOnBitmap(bmp );
                }
                finally
                {
                   bmp.Dispose();
                }   
            });
    
       ProcessNext(); // Has to be called asap after handling this event
    }
