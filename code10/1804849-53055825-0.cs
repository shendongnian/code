    public class Parent{
        [ApiMember(Name = "parentItem")]
        public virtual string Item {get; set;}
    }
    public class Child : Parent {
        [ApiMember(Name = "childItem")]
        public override string Item {get; set;}
    }
