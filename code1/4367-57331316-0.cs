    public static string GeneratePassword(int Length, int NonAlphaNumericChars)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            string allowedNonAlphaNum = "!@#$%^&*()_-+=[{]};:<>|./?";
            string pass = "";
            Random rd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < Length; i++)
            {
                if (rd.Next(1) > 0 && NonAlphaNumericChars > 0)
                {
                    pass += allowedNonAlphaNum[rd.Next(allowedNonAlphaNum.Length)];
                    NonAlphaNumericChars--;
                }
                else
                {
                    pass += allowedChars[rd.Next(allowedChars.Length)];
                }
            }
            return pass;
        }
