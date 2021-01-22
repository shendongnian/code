    public interface IProfile
    {
        string Name { get; }
    }
    
    public partial class ProfileEntity : IProfile
    {
        public string Name
        {
            get
            {
                return this.ProfileEntityName;
            }
        }
    }
    
    public class SomeClass
    {
        public ProfileEntity SomeMethod()
        {
            return ProfileEntity;
        }
    }
    
    public class SomeOtherClass
    {
        SomeClass sc = new SomeClass();
    	
        public void DoSomething()
        {
            IProfile ew = sc.SomeMethod();
        }
    }
