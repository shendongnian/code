    [WebMethod]
    public static bool IsNewDataAvailable(int currentClientRows)
    {
        return dataCollectedSoFar.Count > currentClientRows;
    }
    [WebMethod]
    public static bool IsFinished()
    {
        // return true if all the threads in the thread pool are finished
    }
