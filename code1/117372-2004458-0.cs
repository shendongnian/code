        public static bool IsEmail(this string email)
        {
            if (email != null)
            {
                return Regex.IsMatch(email, "EmailPattern");
            }
            return false;
        }
