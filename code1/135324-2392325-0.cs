    class ConnectionStringProtector
    {
        readonly byte[] _salt = new byte[] { 1, 2, 3, 4, 5, 6 };  // Random values
        readonly Encoding _encoding = Encoding.Unicode;
        readonly DataProtectionScope _scope = DataProtectionScope.LocalMachine;
        public string Unprotect(string str)
        {
            var protectedData = Convert.FromBase64String(str);
            var unprotected = ProtectedData.Unprotect(protectedData, _salt, _scope);
            return _encoding.GetString(unprotected);
        }
        public string Protect(string unprotectedString)
        {
            var unprotected = _encoding.GetBytes(unprotectedString);
            var protectedData = ProtectedData.Protect(unprotected, _salt, _scope);
            return Convert.ToBase64String(protectedData);
        }
    }
