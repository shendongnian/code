    public interface IClassB
    {
       void SomeMethod();
    }
    public Class A
    {
        private IClassB myInstanceB = new ClassB();
        
        public ClassA(){}
        
        public ClassA(IClass B)
        {
          myInstanceB = B;
        }
        public void SomeMethod()
        {
            myInstanceB.SomeMethod();
        }
    }
    public ClassB : IClassB
    {
       public void SomeMethod()
       {
          // some wicked code here...
       }
    }
