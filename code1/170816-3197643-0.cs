    var user = User.Identity.Name;
    var index = user.IndexOf("\\");
    if (index < 0 || index == user.Length - 1) 
    {
        user = string.Empty;
    }
    else 
    {
        user = user.Substring(index + 1);
    }
