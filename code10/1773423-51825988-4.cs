    string httpContent = await httpResponse.Content.ReadAsStringAsync();
    JObject responseObject = JObject.Parse(httpContent);
    int statusCode = (int)responseObject.SelectToken("Status.Code");
    if (statusCode == 1074)
    {
        string exceptionClassName = (string)responseObject.SelectToken("Exception.ClassName");
        Assembly exAssembly = Assembly.Load("myExceptions");
        Type exType = exAssembly.GetType(exceptionClassName, false);
        if (exType != null)
        {
            Exception ex = (Exception)responseObject["Exception"].ToObject(exType);
            throw ex;
        }
        else
        {
            // exception class was not found, so just throw a generic one
            string message = (string)responseObject.SelectToken("Exception.Message");
            throw new Exception(message);
        }
    }
