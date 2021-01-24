    public static void Handle(this AddResult addResult)
    {
        var transformedResult = TransformResult(addResult);
        
        if(CheckValidity(transformedResult))
        {
            SendResult(transformedResult); 
        }
        else
        {
            LogError(transformedResult);
        }
    }
