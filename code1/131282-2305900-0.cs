    public class SomeClassToTest
    {
        private readonly ISomeDependentObject _dep;
        public SomeClassToTest(ISomeDependentObject dep)
        {
            _dep = dep;
        }
    
        public int SomeMethodToTest()
        {
            return _dep.Method1() + _dep.Method2();
        }
    }
