    List<string[]> lList = FromDB();
    string strQuery = String.Empty
    for(int i = 0; i < lList.Count; i++)
    {
        if(strQuery == String.Empty)
            strQuery = lList[i][0] + "|" + lList[i][1];
        else
            strQuery += "|" + lList[i][0] + "|" + lList[i][1];
        if(((i % 11) == 0) && (i != 0))
        {
            SendToRemoteService(strQuery);
            strQuery = String.Empty;
        }
    }
    if (strQuery != String.Empty)
    {
        SendToRemoteService(strQuery);
    }
