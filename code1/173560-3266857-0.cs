    // assuming you can parse your string to get your string to this format.
    string queryStringText = "variableOne=value&variableTwo=someothervalue";
    
    NameValueCollection queryString = 
         HttpUtility.ParseQueryString(queryStringText);
    
    string variable1 = queryString["variableOne"];
    string variable2 = queryString["variableTwo"];
