    public class FooBase
    {
        public virtual void Write(int value)
        {
            //something
        }
    }
    
    public class Foo : FooBase
    {
        public override void Write(int value)
        {
            //something
        }
        public void Write(decimal value)
        {
            //something
        }
    }
