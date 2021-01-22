    private string GetUniqID()
    {
        var ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
        double t = ts.TotalMilliseconds / 1000;
    
        int a = (int)Math.Floor(t);
        int b = (int)((t - Math.Floor(t)) * 1000000);
    
        return a.ToString("x8") + b.ToString("x5");
    }
