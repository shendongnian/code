    bool IsValidEmail(string email)
    {
        try
        {
            email = email.Trim();
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
