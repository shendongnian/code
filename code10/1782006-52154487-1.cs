    public static TransformResult ToTransformResult(this AddResult addResult)
    {
        return new TransformResult(addResult);
    }
    public static void HandleValidity(this TransformResult addResult)
    {
        if(CheckValidity(transformedResult))
        {
            SendResult(transformedResult); 
        }
        else
        {
            LogError(transformedResult);
        }
    }
