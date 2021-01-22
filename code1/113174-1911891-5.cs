    var timer = new System.Threading.Timer((state) =>
    {
         Debug.WriteLine(str);
         Debug.WriteLine(state);
         Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + "  current is timer");
    }, num, 10000, 10000);
