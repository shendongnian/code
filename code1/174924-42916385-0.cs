    public class Patient
    {
        public int Id {get; set;}
        
        [Secure]
        public string FullName {get; set;}
        
        [Secure]
        public string SocialSecurityNumber {get; set;}
    }
