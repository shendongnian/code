     MetadataTestClient client = new MetadataTestClient();
            try
            {
                using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
                {
                    HttpRequestMessageProperty property;
                    if (OperationContext.Current.OutgoingMessageProperties.ContainsKey(HttpRequestMessageProperty.Name)){
                        property = OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
                    }
                    else
                    {
                        property = new HttpRequestMessageProperty();
    //HttpRequestMessagProperty is an item in OutgoingMessageProperties
                        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = property;
                    }
    // add property to HttpRequestMessagePropery could set HttpHeader
                    property.Headers.Add (System.Net.HttpRequestHeader.Authorization, "myAuthorization");
                    string re = client.HelloWorld();
                }
             
             
            }
