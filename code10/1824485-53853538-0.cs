    HashSet<WhateverTypeYourIpIs> hashSet = new HashSet<WhateverTypeYourIpIs>();
    for(int i = 0; i < ip.Count;)
    {
        if(hashSet.Contains(ip[i]))
        {
            ep.Workbook.Worksheets[1].DeleteRow(i + 1);
            ip.RemoveAt(i);
        }
        else
        {
            hashSet.Add(ip[i]);
            i++;
        }
    }
