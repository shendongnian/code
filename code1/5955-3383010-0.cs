    IDisposable d;
    
    Try
    {
        d = Dispatcher.DisableProcessing();
        /* your work... Use dispacher.begininvoke... */
    } Finally {
        d.Dispose();
    }
