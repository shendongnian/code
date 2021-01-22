    public class AccountMap : ClassMap<Account>{        
        public AccountMap()
        {
            
            Id( x => x.Id );
            Map( x => x.Username )
            Map( x => x.Password).Access.AsCamelCaseField();         
        }
    }
    
    public class AccountMap : ClassMap<Account>{        
       private string password;
       public string Password{ get; }
    }
