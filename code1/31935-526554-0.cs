    if (Environment.OSVersion.Platform != PlatformID.Unix)
    {
        Glib.Thread.Init();
    }
    Gdk.Threads.Init();
