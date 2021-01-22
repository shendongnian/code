    List<string> removals = new List<string>();                    
    DateTime now = DateTime.Now;
    foreach(BruteforceEntry be in Entries.Values)
    {
        if (be.AddedTimeRemove <= now ||
            (be.Unbantime <= now && be.Unbantime.Day == DateTime.Now.Day))
        {
            removals.Add(be.IPAddress);
        }
    }
    foreach (string address in removals)
    {
        Entries.Remove(address);
    }
