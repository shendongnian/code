    // Splitting into string lines
    var subArray = sub.Split('\n')
        .Where(x => !string.IsNullOrEmpty(x));
    
    JObject tokenJObj = new JObject();
    foreach (var oneSub in subArray)
    {
    // I assume that the value will be after the last empty character
        tokenJObj.Add(
            oneSub.Substring(0, oneSub.LastIndexOf(' ')).Trim(), 
            oneSub.Substring(oneSub.LastIndexOf(' ') + 1));
    }
    string tokenStringJson1 = tokenJObj.ToString();
    // or
    string tokenStringJson2 = JsonConvert.SerializeObject(tokenJObj);
