    public static bool IsValidEmail(this string InputEmailID)
    {
        var format =
                 @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}.\.[0-9]{1,3}\.)|
                 (([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        Regex Rex=new Regex(format);
        return Rex.IsMatch(InputEmailID);
    }
