    [WebMethod]
    public static string GetCollection(string lvl)
    {
       bool isInserted = false;
       // set the value of isInserted
       // you can send code a numeric value or bool value according to your need
       var result = new {code = isInserted, message = isInserted ? "Succesfully inserted" : "Already Exists"};
       return JsonConvert.SerializeObject(result);
    }
