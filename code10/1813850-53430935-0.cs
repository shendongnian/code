    public class BaseClass<TUser>
    {
        public virtual TUser User { get; set; }
    }
    
    public class Father : BaseClass<CustomUser>
    {
    }
    ...
    child.SetupGet(x=>x.User).Returns (user.Object);  // Works!
