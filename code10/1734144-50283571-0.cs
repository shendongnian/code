    private static void Main()
    {
        var propNamesAndValues = new List<string>
        {
            "PropertName1 = Timothy",
            "PropertName2 = Rajan",
            "PropertName100 = Alex",
        };
        var requestData = new RequestData();
        foreach (var propNameValue in propNamesAndValues)
        {
            var parts = propNameValue.Split('=');
            if (parts.Length < 2) continue;
            var propName = parts[0].Trim();
            var propValue = parts[1].Trim();
            typeof(RequestData).GetProperty(propName)?.SetValue(requestData, propValue);
        }
        Console.WriteLine("{0} {1} {2}", requestData.PropertName1,
            requestData.PropertName2, requestData.PropertName100);
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
