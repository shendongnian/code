    public static class MyCertificate
    {
        private readonly static X509Certificate2 _singletonInstance = GetMyCertificateFromDatabase();
    
        public static X509Certificate2 MyX509Certificate
        {
            get { return _singletonInstance; }
        }
    ...
    }
