    public int SpeedUp()
    {
        this.Speed += 1;
        return (Speed);
    }
    public int SlowDown()
    {
        if (Speed > 0)
        {
            this.Speed -= 1;
        }
        return (Speed);
    }
