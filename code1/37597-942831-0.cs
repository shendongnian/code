    private bool IsValidFacebookSignature()
        {
            //keys must remain in alphabetical order
            string[] keyArray = { "expires", "session_key", "ss", "user" };
            string signature = "";
            foreach (string key in keyArray)
                signature += string.Format("{0}={1}", key, GetFacebookCookie(key));
            signature += SecretKey; //your secret key issued by FB
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(signature.Trim()));
            StringBuilder sb = new StringBuilder();
            foreach (byte hashByte in hash)
                sb.Append(hashByte.ToString("x2", CultureInfo.InvariantCulture));
            return (GetFacebookCookie("") == sb.ToString());
        }
        private string GetFacebookCookie(string cookieName)
        {
            //APIKey issued by FB
            string fullCookie = string.IsNullOrEmpty(cookieName) ? ApiKey : ApiKey + "_" + cookieName;
            return Request.Cookies[fullCookie].Value;
        }
