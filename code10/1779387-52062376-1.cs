    string firstname = "";
    string lastName = "";
    string phoneNumber = "";
    string primary = "";
    string phoneNumber2 = "";
    
    var registrant = new
    {
        firstName = firstname,
        lastName = lastName,
        phones = new[]
        {
            new { phone = phoneNumber, type = "Home", primary = true },
            new { phone = phoneNumber2, type = "Work", primary = false }
        }
    };
    JavaScriptSerializer js = new JavaScriptSerializer();
    string jsonData = js.Serialize(registrant);
