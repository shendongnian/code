    private static RegEx digitsOnly = new RegEx(@"[^\d]");   
 
    public static string CleanPhone(string phone)
    {
        return digitsOnly.Replace(phone, "");
    }
