    private void HandleEvent(object s, OnFrameArgs args)
    {
       var bmp = args.Frame.GetCopy();
    
       Task.Run(() =>
            {
                AnotherObject.CostlyOperationsOnBitmap(bmp );
                bmp.Dipose();
            });
    
       ProcessNext(); // Has to be called asap after handling this event
    }
