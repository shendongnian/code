    List<string[]> lList = FromDB();
    List<string> query = new List<string>();
    for(int i = 0; i < lList.Count; i++)
    {
        query.Add(lList[i][0] + "|" + lList[i][1]);
        if(((((i + 1) % 12) == 0) || (i == lList.Count - 1)) && (i != 0))
        {
            SendToRemoteService(String.Join("|", query.ToArray()));
            query.Clear();
        }
    }
