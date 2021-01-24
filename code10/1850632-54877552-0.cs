        #region Properties
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        #endregion
        public void Initialize()
        {
            try
            {
                // Decrypt username & password
                // this will throw an error if original string is present
                EmailAddress = DecryptString(EmailAddress);
                Password = DecryptString(Password);
            }
            catch (Exception)
            {
                EncryptAppConfig(EmailAddress, Password);
                _log.Info("Encrypted Config file with email and password. ");
            }
        }
