    public interface IVisitor<T> {
        T Visit(Base x);
        T Visit(Derived1 x);
        T Visit(Derived2 x);
    }
    
    class Base {
        public virtual T Accept<T>(IVisitor<T> visitor) { visitor.Visit(this); }
        public string BaseString { get; set; }
    }
    
    class Derived1 : Base {
        public override T Accept<T>(IVisitor<T> visitor) { visitor.Visit(this); }
        public string Derived1String { get; set; }
    }
    
    class Derived2 : Base {
        public override T Accept<T>(IVisitor<T> visitor) { visitor.Visit(this); }
        public string Derived2String { get; set; }
    }
