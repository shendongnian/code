    public static bool IsValidEmail(this string email)
    {
      // return early if possible
      if (email.IndexOf("@") <= 0) return false;
 
      try
      {
        var address = new MailAddress(email);
        return address.Address == email;
      }
      catch
      {
        return false;
      }
    }
