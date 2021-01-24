    List<int> FineListy = new List<int>();
    for (int i = 0; i < fineList.Count(); i++)
    {
        if (fineList[i] > 0)
        {
            FineListy.Add((fineList[i] += fineList[i]));              
        }
    }
