    public static class CustomDbFunctions
    {
    	const string Namespace = "EFTest.MyDbContextModel.Store";
    
    	[DbFunction(Namespace, "IsNull")]
    	public static byte[] IsNull(byte[] expr1, double expr2) => throw new NotSupportedException();
    }
