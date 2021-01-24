    using System.Net.Http;
    ...
    var values  = new Dictionary<string, string>() { { "arg1", "value1" },  { "arg2", "value2" } };
    var content = new FormUrlEncodedContent(values);
    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // enable TLS 1.2
    HttpResponseMessage responseMsg = new HttpClient().PostAsync(@"http://some.server.com/data.csv", content).Result;
    if (responseMsg.StatusCode != System.Net.HttpStatusCode.OK) throw new Exception("err msg");
    File.WriteAllText(@"c:\temp\data.csv", responseMsg.Content.ReadAsStringAsync().Result);
    ...
