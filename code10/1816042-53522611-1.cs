    using (var webResponse = soapRequest.EndGetResponse(asyncResult))
    {
        string myResult;
        var responseStream = webResponse.GetResponseStream();
        if (responseStream == null)
        {
            return null;
        }
        using (var reader = new StreamReader(responseStream))
        {
            myResult = reader.ReadToEnd();
        }
        var deserializedResult = YourDeserializationLogic(myResult);
        if(deserializedResult != null && deserializedResult.Error != null)
        {
           //Do your error handling Logic
        }
        else if(deserializedResult != null && deserializedResult.NewTag != null)
        {
           //Do your post success logic
        }
    }
