      // Session ID received from web service as response to authentication login
      private string _sessionId;
         // This code needed to add the session ID to the HTTP header as a JSESSIONID cookie value
         using (MyServiceClient myServiceClient = new MyServiceClient())
         using (new OperationContextScope(myServiceClient.InnerChannel))
         {
            HttpRequestMessageProperty httpRequestProperty = new HttpRequestMessageProperty();
            httpRequestProperty.Headers.Add("Cookie", "JSESSIONID=" + _sessionId);
            OperationContext.Current.OutgoingMessageProperties.Add(
                                              HttpRequestMessageProperty.Name, httpRequestProperty);
            myServiceClient.someMethod();
         }
