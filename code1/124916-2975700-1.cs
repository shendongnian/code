    public class BaseClass<TChild> where TChild : BaseClassCollection {
        public virtual ICollection<TChild> Collection { get; set; }
    }
        
    public class ChildClass<TChild> : BaseClass<TChild> where TChild : ChildClassCollection {
        public override ICollection<TChild> Collection { get; set; }
    }
    public class BaseClassCollection { }
    public class ChildClassCollection : BaseClassCollection { }
