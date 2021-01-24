    public class AuthorizePropertyAttribute : Attribute
    {
        public AuthorizePropertyAttribute(string role) => Role = role;
        public string Role { get; set; }
    }
