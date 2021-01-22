public DateCheckResponseGetDate(DateCheckRequest requestParameters)
{
    Func&lt;DateCheckRequest, DateCheckResponse&gt; getTheDate = new Func&lt;DateCheckRequest, DateCheckResponse&gt;(WebServices.GetTheDate);
    return CallWebMethod(getTheDate , requestParameters);
}
//DEFINE CallWebMethod ADEQUATELY!
public T CallWebMethod&lt;T,U&gt; (Func&lt;T,U&gt; webMethod, U arg)
{
    return webMethod(arg);
}
