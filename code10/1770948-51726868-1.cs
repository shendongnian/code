    public static void Main(string[] args)
    {
        LoadCampaignTempleteJSONAsync().Result;
        LoadCampaignTempleteJSONAsync().GetAwaiter().GetResult();
    }
