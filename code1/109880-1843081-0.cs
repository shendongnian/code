    public class ConnectionStringProvider {
        public string ConnectionString {
            get{
                 // your impl here
            }
        }
    }
    public class UserRepository {
       public UserRepository(ConnectionStringProvider provider){
            // set internal field here to use later
            // with db connection
       }
    }
