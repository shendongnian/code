    public class UserRepository : IUserRepository {
        public UserRepository(IObjectContext objectContext, object fakeIgnoreMe)  {
            // Check that the supplied arguments are valid.
            Validate.Arguments.IsNotNull(objectContext, "objectContext");
            // ignoring fake additional argument
            // Initialize the local fields.
            ObjectContext = objectContext;
        }
    
        public UserRepository(IObjectContextFactory factory) 
            : this(factory.CreateObjectContext()) { 
        }
    
        // -----------------------------------------------
        // Insert methods and properties...
        // -----------------------------------------------
    }
