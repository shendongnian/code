    [WebMethod]
    public static bool IsNewDataAvailable(int currentClientRows)
    {
        return dataCollectedSoFar.Count > currentClientRows;
    }
