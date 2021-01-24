    [TestCategory("ServiceTests")]
    [TestMethod]
    public void CallServiceCalc() {
        var client = new RestClient();
        client.BaseUrl = new Uri("https://localhost:44379");
        client.Authenticator = new HttpBasicAuthenticator("eric.schneider", "password");
        var request = new RestRequest(Method.POST); //<-- POST request
        request.Resource = "api/Calculation/Calculate";
        request.AddHeader("content-type", "application/json");
        CoralRequest coralReq = new CoralRequest();
        coralReq.ModelId = 1;
        coralReq.ModelName = "2018";
        coralReq.BasePlan = new BeneifitsPlanInputs();
        coralReq.Plans.Add(new BeneifitsPlanInputs());
        request.AddJsonBody(coralReq); //<-- adding data as JSON to body of request
        IRestResponse response = client.Execute(request);
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK, "Should be HttpStatusCode.OK");
    }
    
