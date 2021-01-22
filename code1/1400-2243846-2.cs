    public class User
        {
            private long _UserId;
            private String _Name;
            private String _Password;
            private String _Email;
   
            // Properties
            public long UserId
            {
                get { return this._UserId; }
                set { this._UserId = value; }
            }
    
            public String Name
            {
                get { return this._Name; }
                set { this._Name = value; }
            }
    
            public String Password
            {
                get { return this._Password; }
                set { this._Password = value; }
            }
    
            public String Email
            {
                get { return this._Email; }
                set { this._Email = value; }
            }
    
        }
