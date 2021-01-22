    public DateCheckResponseGetDate(DateCheckRequest requestParameters)
    {
        // Split declaration/assignment just to avoid wrapping
        Func<DateCheckRequest, DateCheckResponse> method;
        method = WebServices.GetTheDate;
        return CallWebMethod(method, requestParameters);
    }
