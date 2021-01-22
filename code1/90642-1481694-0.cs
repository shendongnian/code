    public object DeserializeReply(Message message, object[] parameters)
    {
        object helperInstance = Activator.CreateInstance(_return);
    
        //we have special condition where service sets Http response code to 403 that signals that an error has occured 
        KeyValuePair<string,object> serviceErrorProperty = message.Properties.FirstOrDefault(p => p.Key == ResponseErrorKey);
        if (serviceErrorProperty.Key != null)
        {
            //we have an error message
            IResponseErrorProvider responseErrorProvider = helperInstance as IResponseErrorProvider;
            if (responseErrorProvider != null)
            {
                //unpack the error payload from message and assign to the object
                ResponseError payload = message.GetBody<ResponseError>();
                responseErrorProvider.ServiceError = payload;
    
                //return fixed null type with error attached to it
                return helperInstance;
            }
        }
    
        //another message we might get is <nil-classes type="array"/> for empty arrays.
        XmlDictionaryReader xdr = message.GetReaderAtBodyContents();
        xdr.MoveToContent();
        
        if (xdr.Name == NullMessage)
        {
            return helperInstance; //standin for the null value
        }
    
        return _formatter.DeserializeReply(message, parameters);
    }
    
    public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
    {
        return _formatter.SerializeRequest(messageVersion, parameters);
    }
