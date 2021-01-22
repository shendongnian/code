    public void Stop()
    {
        if (this.connection.IsAlive)
        {
            this.stopCondition = true;
            this.connection.Join();
        }
    }
