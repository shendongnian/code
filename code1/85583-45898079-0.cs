    For the simple email like goerge@xxx.com, below code is sufficient. 
     public static bool ValidateEmail(string email)
            {
                System.Text.RegularExpressions.Regex emailRegex = new System.Text.RegularExpressions.Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                System.Text.RegularExpressions.Match emailMatch = emailRegex.Match(email);
                return emailMatch.Success;
            }
