    private static Regex digitsOnly = new Regex(@"[^\d]");   
 
    public static string CleanPhone(string phone)
    {
        return digitsOnly.Replace(phone, "");
    }
