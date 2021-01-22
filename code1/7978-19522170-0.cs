        try
        {
            string functionReturnValue = null;
            String oRequestHttp =
                WebOperationContext.Current.IncomingRequest.Headers["User-Host-Address"];
            if (string.IsNullOrEmpty(oRequestHttp))
            {
                OperationContext context = OperationContext.Current;
                MessageProperties prop = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint =
                    prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                oRequestHttp = endpoint.Address;
            }
            return functionReturnValue;
        }
        catch (Exception ex)
            {
                return "unknown IP";
            }
    }
