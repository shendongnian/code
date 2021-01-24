    string json = "{\"request\":{\"path\":\"1\",\"coverages\":{\"path\":\"2\",\"broadcastCoverage\":{\"path\":\"3\",\"name\":\"First Coverage\",\"channel\":\"Channel 9\",\"callSign\":\"DSOTM\"},\"internetCoverage\":{\"path\":\"4\",\"name\":\"Second Coverage\",\"url\":\"www.stackoverflow.com\"},\"thirdCoverage\":{\"path\":\"5\",\"name\":\"Third Coverage\",\"differentProperty\":\"Units\"}}}}";
    var jsonReq = JObject.Parse(json);
    var pathVal = jsonReq["request"]["path"].Value<string>();
    var coverageObjects = jsonReq["request"]["coverages"].Value<JObject>();
    var filteredObjects = coverageObjects.Children().Where(x => x.Value<JProperty>().Name.EndsWith("Coverage"));
    var dictionary = filteredObjects.Select(x => new KeyValuePair<string, string>(x.Value<JProperty>().Name, x.Value<JProperty>().Value.ToString()));
    // reformatted Json
    var newJson = "{ \"path\":\"" + pathVal + "\", \"coverages\" : [" + String.Join(",", dictionary.Select(x => x.Value).ToList()) + "]}";
    Request reqC = JsonConvert.DeserializeObject<Request>(newJson);
