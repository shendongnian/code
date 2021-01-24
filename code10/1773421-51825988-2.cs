    string httpContent = await httpResponse.Content.ReadAsStringAsync();
    JObject responseObject = JObject.Parse(httpContent);
    int statusCode = (int)responseObject.SelectToken("Status.Code");
    if (statusCode == 1074)
    {
        string exceptionClassName = (string)responseObject.SelectToken("Exception.ClassName");
        Assembly ExAssembly = Assembly.Load("myExceptions");
        Type exType = ExAssembly.GetType(exceptionClassName, true);
        Exception ex = (Exception)responseObject["Exception"].ToObject(exType);
        throw ex;
    }
