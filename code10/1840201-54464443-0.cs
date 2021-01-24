    public class User
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        //FYI ShouldSerialize_PROPERTY_NAME_HERE()
       public bool ShouldSerializePasswordHash()
        {
            // use the condtion when it will be serlized
            return (PasswordHash != this);
        }
    }
