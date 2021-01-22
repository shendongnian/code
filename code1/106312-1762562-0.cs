    StreamWriter _Writer;
    using(_Writer)
    {
        if (_WriterOpen == false)
        {
           _Writer = new StreamWriter(_WorkingDir + _Logfile, true);
           _WriterOpen = true;
           _Writer.AutoFlush = true;
        }
        _Writer.WriteLine(DateTime.Now.ToString() + ": " + String.Format(Note, Args));
    }
