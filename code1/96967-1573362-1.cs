        bool IsPasswordValid(string password)
        {
            if (string.IsNullOrEmpty(password) ||
                password.Length > 20 ||
                password.Length < 6)
            {
                return false;
            }
            else if(!Regex.IsMatch(password, "\d") ||
                !Regex.IsMatch(password, "[a-z]") ||
                !Regex.IsMatch(password, "[A-Z]"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
