    //parse JSON and grab it's children. 
    var JSONobj = JObject.Parse(test).Children();
    //turn into dictionary of property name and value using linq
    var dictionary = JSONobj
    .Select(s => (s as JProperty))
    .ToDictionary(u => u.Name, v => v.Value);
    var ExchangeRateToExchangeDetailsDictionary = 
    //grab result or error
    dictionary["result"]
    .Select(s => (s as JProperty))
    .ToDictionary(u => u.Name, 
    v => JsonConvert.DeserializeObject<ExchangeRateItem>(v.Value.ToString()));
    //you can iterate through your dictionary like this
    foreach (var kvp in ExchangeRateToExchangeDetailsDictionary)
    {
        //this is just string key of the exchangeRateCode
        var exchangeRate = kvp.Key;
        //this will return the ExchangeRateItem object. 
        var exchangeRateDetails = kvp.Value;
    }
    //you can also get the ExchangeRateItem object per exchangeRate like this
    var giveMeUSExchangeRate = ExchangeRateToExchangeDetailsDictionary["USD"];
    //if you need to just return a list of ExchangeRateItem objects you can do this
    List<ExchangeRateItem> listOfExchangeRateItem = ExchangeRateToExchangeDetailsDictionary.Values.ToList();
