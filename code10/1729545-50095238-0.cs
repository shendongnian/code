    public static string ToDateTime(this myString)
    {
        var date = Convert.ToDateTime(myString).ToString("DD / MM / YYYY");
        return date;
    }
    string YourDateTime = "29-04-2018 09:43:33";
    
    var Result =YourDateTime.ToDateTime();  // "29/04/2018"
