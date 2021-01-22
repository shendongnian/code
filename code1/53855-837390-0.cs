    public void IncreaseCounter()
    {
        this.Counter += 1;
        try
        {
            OnCounterChanged(EventArgs.Empty);
        }
        catch
        {
            this.Counter -= 1;
        }
    }
