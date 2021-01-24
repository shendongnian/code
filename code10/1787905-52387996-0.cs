    [WebMethod]
    public static string RefreshChartEcg(string columnname, string inputVal)
    {
         ....
         Array list = getActivitiesExecution(lastID: lastID).ToArray();
         var sRet = {YourSerilizationHelper}.Serialize(list);
         return sRet;
    }
    you need your own serializer to do this according to your requirements.
