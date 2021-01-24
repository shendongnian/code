    bool contains = false;
    for(int c = 0; c < intTestResult.Count; c++)
    {
        if(int1 == intTestResult[c])
        {
            contains = true;
            break;
        }
    }
    if(!contains)
        intTestResult.Add(int1);
