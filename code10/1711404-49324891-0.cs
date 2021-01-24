    // First example
    const string originalExample =
        "{\"name\": {},\"percentage\": [{\"math\": {\"2.503300099.1\": 460800,\"2.503300099.2\": 460800},\"english\": {\"2.503300099\": \"hello\"}}]}";
    var myFirstDynamic = JsonConvert.DeserializeObject<dynamic>(originalExample);
    Console.WriteLine(myFirstDynamic["percentage"][0]["math"]["2.503300099.1"]); // -> 460800
    // Second example
    const string newExample =
                "{\"One\": {},\"Two\": [{\"twoA\": {\"2.503300099.1\": 460800,\"2.503300099.2\": 460800,},\"TwoB\": {\"2.503300099\": \"value\",\"2.503308292\": \"value\"},\"TwoC\": {\"2.503300099\": \"value\",\"2.503308292\": \"value\"},\"exam\": \"2.0\"}]}";
    var mySecondDynamic = JsonConvert.DeserializeObject<dynamic>(newExample);
    Console.WriteLine(mySecondDynamic["Two"][0]["twoA"]["2.503300099.1"]); // -> 460800;
