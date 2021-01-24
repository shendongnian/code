    public ActionResult IsPhoneOrEmail(string notification) 
    {
         Regex phoneRegex = new Regex(@"^([0-9\(\)\/\+ \-]*)$");
         Regex emailRegex = new Regex("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
         return (emailRegex .IsMatch(notification) || phoneRegex.IsMatch(notification));
    }
