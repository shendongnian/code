    string Email = txtEmail.Text;
    if (Email.IsValidEmail())
    {
       //use code here 
    }
    
    public static bool IsValidEmail(this string email)
    {
      string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";    
      var regex = new Regex(pattern, RegexOptions.IgnoreCase);    
      return regex.IsMatch(email);
    }
