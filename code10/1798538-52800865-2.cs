    TimeSpan start = TimeSpan.Zero;
    TimeSpan minutes = TimeSpan.FromMinutes(1);
    var timer = new System.Threading.Timer(c =>
    {
        MyFunction();
    }, null, start, minutes);
