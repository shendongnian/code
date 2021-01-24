    public void Stop()
    {
        if(clockPin != null )
        {
            clockPin.Dispose();
        }
        if(dataPin != null)
        {
            dataPin.Dispose();
        }
    }
