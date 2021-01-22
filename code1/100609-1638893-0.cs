    class Program
    {
        static void Main(string[] args)
        {
            var builder = new UserBuilder();
            builder.BuildTypeA().WithRoles("a,b");
            builder.BuildTypeB().WithLocations("c,d");
        }
    }
    
    public abstract class User {}
    public class UserA : User {}
    public class UserB : User {}
    
    public class UserBuilder
    {
        public UserABuilder BuildTypeA() { return new UserABuilder(); }
        public UserBBuilder BuildTypeB() { return new UserBBuilder(); }
    }
    
    public class UserABuilder
    {
        public UserABuilder WithRoles(string roles)
        {
            // add roles
            return this;
        }
    }
    
    public class UserBBuilder
    {
        public UserBBuilder WithLocations(string locations)
        {
            // add locations
            return this;
        }
    }
