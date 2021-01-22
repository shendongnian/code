    Configuration config = new Configuration(dataRowSet[0]["ServiceUrl"].ToString());
                var remoteAddress = new System.ServiceModel.EndpointAddress(config.Url);
             
                SimpleService.PayPointSoapClient client = new SimpleService.PayPointSoapClient(new System.ServiceModel.BasicHttpBinding(), remoteAddress);
                SimpleService.AccountcredResponse response = client.AccountCred(request);
