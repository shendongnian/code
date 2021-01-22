    public class MyType
    {
        private SomeType _myNeeds;
        // constructor
        MyType(SomeType iWillNeedThis)
        {
            _myNeeds = iWillNeedThis;
        }
        // method
        public void MyMethod()
        {
            DoSomethingAbout(_myNeeds);
        }
    }
