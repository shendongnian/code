    //...code removed for brevity
    string requestXML = string.Empty;
    mockRestClient
        .Setup(_ => _.Execute(It.IsAny<IRestRequest>()))
        .Returns((IRestRequest request) => {
            var parameter = request.Parameters.Where(p => p.Name == "application/xml").FirstOrDefault();
            if(parameter != null && parameter.Value != null) {
                requestXML = parameter.Value.ToString();
            }
            
            return testRestResponse;
        });
        
    //...code removed for brevity
    
    
    Assert.Equal(requestXML, testRequestXML);
