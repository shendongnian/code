        var url = @"http://blahblah/status";
        string xmlContent = "<XML><test><name>Mark</name></test></XML>"; //CHANGED
        var client = new RestClient(url);
        var request = new RestRequest(Method.POST);
        request.AddHeader("Content-Type", "text/xml");  //CHANGED
        request.AddHeader("cache-control", "no-cache");
        request.AddParameter("text/xml", xmlContent , ParameterType.RequestBody);  //CHANGED
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        response = client.Execute(request);
