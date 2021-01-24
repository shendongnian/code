     Auth.AuthSoapClient authSoapClient = new Auth.AuthSoapClient();
            using (new OperationContextScope(authSoapClient.InnerChannel))
            {
    // please put the call of method in OperationContextScope
                authSoapClient.Login("admin", "admin");
              // the following code get the set-cookie header passed by server
             
                HttpResponseMessageProperty response = (HttpResponseMessageProperty)
                OperationContext.Current.IncomingMessageProperties[
                    HttpResponseMessageProperty.Name];
                string header  = response.Headers["Set-Cookie"];
              // then you could save it some place  
            }
