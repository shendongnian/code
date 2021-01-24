    [WebMethod]
    public static string StoreGridData(object[] obj)
    {
       if (obj.Length == 0) return string.Empty;
       //save values to database
       return "Success";
    }
