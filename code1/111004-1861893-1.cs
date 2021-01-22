    public string emailLink(string emailAddress)
    {
        Regex emailRegex = new Regex(@"^[a-zA-Z][\w\._%+-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
        if (emailRegex.IsMatch(emailAddress)
        {
            return string.Format("<a href=\"mailto:{0}\">{0}</a>", emailAddress);
        }
        return "";
    }
