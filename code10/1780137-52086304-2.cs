     public static void AddPing(String message, IDictionary<string, string> dict)
    {
        dict["NET_MSG"] = message;
        dict["IP"] = get_IP();
        dict["HOST"] = get_host();
    }
