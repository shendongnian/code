	public void Process(Request request, string statusCode = null, string statusVal= null) 
	{ 
		statusCode = statusCode ?? request.statusCode;
		statusVal = statusVal ?? request.statusVal;
		... 
	}
