    public int ToUnixTime(DateTime d)
    {
        var epoch = new DateTime(1970,1,1);
        return (int)(d - epoch).TotalSeconds;
    }
