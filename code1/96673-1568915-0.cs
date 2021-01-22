    System.Threading.Timer timer = null;
    timer = new System.Threading.Timer(
        (object state) => { DoSomething(); timer.Dispose(); }
        , null // no state required
        ,TimeSpan.FromSeconds(x) // Do it in x seconds
        ,TimeSpan.FromMilliseconds(-1)); // don't repeat
