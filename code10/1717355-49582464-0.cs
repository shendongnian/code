    static Dictionary<string, int> cityList = 
        new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
    static void SomeMethod(SomeType e)
    {
        var weatherQuery = "what is the weather like in";
        int cityId;
        string userInput = e.PartialResult.ToString().Trim();
        if (userInput.StartsWith(weatherQuery, StringComparison.OrdinalIgnoreCase) &&
            cityList.TryGetValue(userInput.Substring(weatherQuery.Length).Trim(), out cityId))
        {
            // We have a weather query and have located the cityId
            CallSomeWeatherAPI(cityId);
        }
    }
