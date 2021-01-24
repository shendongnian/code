    [WebMethod]
    public static string GetDataFromDB()
    {
        var myData = YourDbCall(); // Some method to retrieve data from database
        var body = new 
        {
            Firstname = myData.Firstname,
            Lastname = myData.Lastname,
            Email = myData.Email,
            // Any Other Information
        };
        var json = JsonConvert.SerializeObject(body);
        return json;
        
    }
