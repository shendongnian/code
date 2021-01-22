    public static bool IsEmail(string strEmail)
    {
        Regex rgxEmail = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                   @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                   @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        return rgxEmail.IsMatch(strEmail);
    }
