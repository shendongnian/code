    private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
        Test2[1] += (ushort)2;
        PropertyChanged(this, new PropertyChangedEventArgs(nameof(Test)));
    }
