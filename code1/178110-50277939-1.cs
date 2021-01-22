        public class MDBContext : DbContext
        {    
          public MDBContext () : base(GetRemoteConnectionString())
          {
          }
          ......
        }
