    public class ABC_Base<TChild>
    {
        public IEnumberable<TChild> Children { get; set; }
        public void AddChild(TChild item) 
        {
        }
        public void RemoveChild(TChild item)
        {
        }
        //etc
    }
    
    public class A : ABC_Base<X> // X is the type for your child
    {
    
    }
    //Used like so...
    A myA = new A();
    myA.AddChild(new X());
    // or if you are wanting to specify when created then this...
    public class A<TChild> : ABC_Base<TChild>
    {
    }
    //Used like so...
    A myA = new A<X>();
    A myOtherA = new A<Y>();
    myA.Addchild(new X());
    myOtherA.AddChild(new Y());
