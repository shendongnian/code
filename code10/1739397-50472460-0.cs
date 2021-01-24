    public class UserDTO {
        public int Key { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }    
    }
    
    public class VerboseUserDTO: UserDTO {
        public string Suffix { get; set; }
        public Address Address {get;set;}       
    }
