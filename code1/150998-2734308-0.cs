    abstract class A
    {
        public virtual void SomeBehavior()
        {
            //default behavior
        }
    }
    class B:A
    {
        public override void SomeBehavior()
        {
             //type specific behavior
        }
    }
    class C:A
    {
        public override void SomeBehavior()
        {
             //different behavior
        }
    }
    IEnumerable<A> myCollection=new A[]{new B(),new C()};
    foreach(A item in myCollection)
    {
        item.SomeBehavior();
    }
