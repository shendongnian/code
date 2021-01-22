        public static bool isValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address == email)
                {
                    string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*"; 
                    if (Regex.IsMatch(email, expression))
                    {
                        if (Regex.Replace(email, expression, string.Empty).Length == 0) 
                            return true; 
                    }
                    return false;
                }
                return false; 
            }
            catch
            {
                return false;
            }  
        }
