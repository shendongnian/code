        public class UserPass
        {
        	public string Username{get;set;}
        	public string Password{get;set;}
        }
        
        public class User
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public DateTime? Birthday { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public DateTime? LastLogin { get; set; }
            public DateTime? CreateDateTime { get; set; }
            public DateTime? UpdateDateTime { get; set; }
            public bool? Blocked { get; set; }
            public bool? HasOrders { get; set; }
        }
    
