    Stopwatch _sw = new Stopwatch();
    void Button1_Click(sender, e)
    {
        if (_sw.IsRunning) 
            _sw.Stop();
        _sw.Reset();
        _sw.Start();
    }
    void Button2_Click(sender, e)
    {
        if (_sw.IsRunning)   
            _sw.Stop();
        MessageBox.Show(_sw.Elapsed);
    }
