        public IRegisteredUser RegisterUser(string userName, string referrerName)
        {
            userName.AssertNonEmpty("userName");
            referrerName.AssertNonEmpty("referrerName");
            ...
        }
