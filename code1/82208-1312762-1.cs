    public class MyClass
    {
        public virtual void Test() {}
        public void CallTest()
        {
            this.Test();
        }
    }
    public class MyClass2 : MyClass
    {
        public override void Test() {}
    }
