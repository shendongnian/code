     Auth.AuthSoapClient authSoapClient = new Auth.AuthSoapClient();
            using (new OperationContextScope(authSoapClient.InnerChannel))
            {
                 //below code sends the cookie back to server
           
                HttpRequestMessageProperty request = new HttpRequestMessageProperty();
                request.Headers["Cookie"] =  please get the cookie you stored when you   successfully logged in               
     OperationContext.Current.OutgoingMessageProperties[
                    HttpRequestMessageProperty.Name] = request;
    // please put the call of method in OperationContextScope
                string msg = authSoapClient.GetMsg();
            }
