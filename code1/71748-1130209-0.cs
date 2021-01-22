    public class MyType
    {
        private SomeType _myNeeds;
        // constructor
        MyClass(SomeType iWillNeedThis)
        {
            _myNeeds = iWillNeedThis;
        }
        // method
        public void MyMethod()
        {
            DoSomethingAbout(_myNeeds);
        }
    }
