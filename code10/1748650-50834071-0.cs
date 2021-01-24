    public static void SendDataToES(String startTimestamp, String startDate, String bid_x, String ask_x, IList<string> nameABC, string[] getABCs)
    {
        var tem_ehm = new Pre_Market
        {
            timestamp = startTimestamp,
            date = startDate,
            bid = bid_x,
            ask = ask_x,
            ABCs = new Dictionary<string, string>()
        };
        int i = 0;
        foreach (string name in nameABCs)
            tem_ehm.Add(name, getABCs[i++];
        // access the ABCs like so:
        string A = tem_ehm.ABCs["A"];
        string B = tem_ehm.ABCs["B"];
        string C = tem_ehm.ABCs["C"];
    }
    class Pre_Market
    {
        public string x_ric { get; set; }
        public string ask { get; set; }
        public string bid { get; set; }
        public string date { get; set; }
        public string timestamp { get; set; }
        public Dictionary<string, string> ABCs { get; set; }
    }
