    private static object sync = new object();
    static string JsonPrint(string contentString, string imageFilePath)
    {
        lock (sync)
        {
            //DO STUFF
        }
    }
