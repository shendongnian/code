    public static string GetPort(Dictionary<Process, string> OriginalprocessesIDs)
        {
            string ret = "";
            foreach(var p in processesIDs)
            {
                if(p.Key.HasExited)
                {
                    ret = p.Value;
                    OriginalprocessesIDs.Remove(p.Key);
                    return ret;
                }
            }
            return ret;
        }
