    static void Main(string[] args)
    {
           var json = str; // below json is stored in file jsonFile
        var jObject = JObject.Parse(json);
        JArray ZoneMappingArray = (JArray)jObject["DeviceTypeWithResponseTypeMapper"];
        string strDeviceType = "Police";
        string strResponseType = "NotUsed";
        var JToken = ZoneMappingArray.Where(obj => obj["DeviceType"].Value<string>() == strDeviceType).ToList();
        var isrespTypeThere = JToken[0].Last().Values().Any(x => x.Value<string>() == strResponseType);
        Console.WriteLine($"Does {strDeviceType} have response type with value {strResponseType}? {yesorno(isrespTypeThere)}");
    }
    private static object yesorno(bool isrespTypeThere)
    {
        if (isrespTypeThere)
        {
            return "yes!";
        }
        else
        {
            return "no :(";
        }
    }
