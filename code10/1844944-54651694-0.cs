    internal class User
    {
        public string userId { get; set; }
        public string password { get; set; }
        public string userName { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string[] GetProperties()
        {
            return new string[]
            {
                userId,
                password,
                userName,
                address,
                email,
                phone
            };
        }
        static PropertyInfo[] properties = typeof(User).GetProperties();
        public string[] GetPropertiesAuto()
        {
            return properties.Select((prop) => prop.GetValue(this) as string).ToArray();
        }
    }
