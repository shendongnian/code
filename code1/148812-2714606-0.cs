    [WebMethod(CacheDuration = 0, EnableSession = true)]
    public static YourResultType YourMethodName(string param1,int param2)
    {
        YourResultType result=new YourResultType();
        result.x1=true;
        result.x2="The Response can be in any type";
	return result;
    }
