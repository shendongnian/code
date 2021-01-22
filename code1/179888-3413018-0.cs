    ...
    else if (sLeft.Count > 1 && sRight.Count == 0)  //<-- sRight is empty
    {
        for (int i=0; i<sLeft.Count; i++)
        {
            if (sRight[0] <= sLeft[i]) //<-- IndexError?
            {
                sLeft.Insert(i, sRight[0]);
                return sLeft;
            }
        }
        sLeft.Add(sRight[0]);
        return sLeft;
    }
    ...
