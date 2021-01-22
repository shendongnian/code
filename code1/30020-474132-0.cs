    if(this.ContainsKey("ProcessingSleepTime"))
    {
        try {
             object sleepTime = this["ProcessingSleepTime"];
             int sleepInterval;
             if(Int32.TryParse(sleepTime.ToString(), out sleepInterval)
                return sleepInterval;
             else
                 return 100;
        }
        catch {
            return 100;
        }
    }
    else
        return 100;
