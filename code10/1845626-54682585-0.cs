    ServicePointManager.Expect100Continue = true;
    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
    var httpclient = new HttpClient();
    int retries = 5;
    int count = 0;
    var html = await httpclient.GetStringAsync(url);
    while(String.IsNullOrEmpty(html) && count++ < retries) {
        var html = await httpclient.GetStringAsync(url); }
    if(String.IsNullOrEmpty(html)) {
        throw new Exception("Could not contact the server"); }
