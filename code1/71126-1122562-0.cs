    public class AccountMap : ClassMap<Account>{        
        public AccountMap()
        {
            Not.LazyLoad();
            Id( x => x.Id );
            Map( x => x.Username ).LazyLoad();
            Map( x => x.Password );        
        }
    }
