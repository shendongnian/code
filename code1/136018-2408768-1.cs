    public class ProfileEntity
    {
        public string ProfileEntityName { get; set; }
    }
    public class ProfileEntityWrapper
    {
        public ProfileEntityWrapper(ProfileEntity entity)
        {
            Entity = entity;
        }
        public ProfileEntity Entity { get; private set; }
        public string Name
        {
            get
            {
                return Entity.ProfileEntityName;
            }
        }
    }
    public class SomeClass
    {
        public ProfileEntity SomeMethod()
        {
            // example of method returning this object
            ProfileEntity temp = new ProfileEntity();
            return temp;
        }
    }
    public class SomeOtherClass
    {
        SomeClass sc = new SomeClass();
        public void DoSomething()
        {
            //Create a new Wrapper for an existing Entity
            ProfileEntityWrapper ew = new ProfileEntityWrapper(sc.SomeMethod());
        }
    }
