    public class Someclass
    {
        public ProfileEntity SomeMethod()
        {
             return new ProfileEntityWrapper(); // it's legal to return a ProfileEntity
        }
    }
