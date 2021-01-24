        public string login(System.Security.SecureString username, System.Security.SecureString password)
        {
            externalObject.WriteLine("login {0} {1}", username, password);
            string response = externalObject.Execute();
            return response;
        }
    }
    class SecureLibrary {
        public System.Security.SecureString GetSecureString(string text)
        {
            System.Security.SecureString strSecure = new System.Security.SecureString();
            foreach (char c in text)
            {
                strSecure.AppendChar(c);
            }
            return strSecure;
        }
    }
    class HomePage
    {
        public string callLoginMethod()
        {
            string username = "dummyUsername";
            string password = "dummyPassword";
            Library library = new Library();
            SecureLibrary seclib = new SecureLibrary();
            string output = library.login(seclib.GetSecureString(username), seclib.GetSecureString(password));
        }
    }
