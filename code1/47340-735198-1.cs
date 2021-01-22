    private delegate object WebMethodToCall<T>(T methodObject);
    public DateCheckResponseGetDate(DateCheckRequest requestParameters)
    {
        WebMethodToCall<DateCheckRequest> getTheDate = new WebMethodToCall<DateCheckRequest>(WebServices.GetTheDate);
        return CallWebMethod<DateCheckResponse, DateCheckRequest>(getTheDate, requestParameters);
    }
    public TimeCheckResponse GetTime(TimeCheckRequest requestParameters)
    {
        WebMethodToCall<TimeCheckRequest> getTheTime = new WebMethodToCall<TimeCheckRequest>(WebServices.GetTheTime);
        return CallWebMethod<TimeCheckResponse, TimeCheckRequest>(getTheTime, requestParameters);
    }
    private T CallWebMethod<T, U>(WebMethodToCall<U> method, U methodObject)
    {
        return (T)method(methodObject);
    }
