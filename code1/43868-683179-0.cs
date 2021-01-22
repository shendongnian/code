    private Update BuildMetaData(MetaData[] nvPairs)
    {
        Update update = new Update();
        InputProperty[] ip = new InputProperty[20];  // how to make this "dynamic"
        int i;
        for (i = 0; i < nvPairs.Length; i++)
        {
            if (nvPairs[i] == null) break;
            ip[i] = new InputProperty(); 
            ip[i].Name = "udf:" + nvPairs[i].Name;
            ip[i].Val = nvPairs[i].Value;
        }
        if (i < nvPairs.Length)
        {
            // Create new, smaller, array to hold the items we processed.
            update.Items = new InputProperty[i];
            Array.Copy(ip, update.Items, i);
        }
        else
        {
            update.Items = ip;
        }
        return update;
    }
