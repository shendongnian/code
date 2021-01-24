    client.ClientCredentials.UserName.UserName = "";
    client.ClientCredentials.UserName.Password = "";
                
    var httpRequestProperty = new HttpRequestMessageProperty();
    httpRequestProperty.Headers[HttpRequestHeader.Authorization] = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(client.ClientCredentials.UserName.UserName + ":" + client.ClientCredentials.UserName.Password));
                client.Open();
                var context = new OperationContext(client.InnerChannel);
                using (new OperationContextScope(context))
                {
                    context.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
                   
                    client.SampleMethodCall();
                }
