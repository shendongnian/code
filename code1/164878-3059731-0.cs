    public class MyNewClass : IMyNewInterface
    {
        private MyConcreteClass _MyConcreteClass;
    
        public void MyNewClass(MyConcreteClass concreteClass)
        {
            _MyConcreteClass = concreteClass;
        }
    
        public void Method1()
        {
            _MyConcreteClass.Method1();
        }
    }
