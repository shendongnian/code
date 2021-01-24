    int? statusCode = null;
    ObjectResult result = context.Result as ObjectResult;
    statusCode = result?.StatusCode;
    
    if (statusCode == null)
    {
        StatusCodeResult statusResult = context.Result as StatusCodeResult;
        statusCode = statusResult?.StatusCode;
    }
