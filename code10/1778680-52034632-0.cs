    //your classes: internal
    internal class TestBase // Base class that I dont want to expose
    {
        
    }
    //note: added interface
    internal class TestFunctions : TestBase, IYourTestClass // The class that I want to expose
    {
    }
    //an interface to communicate with the outside world:
    public interface IYourTestClass
    {
        //bool Test();  some functions and properties
    }
    //and a public factory method (this is the mot simple version)
    public static class TestClassesFactory
    {
        public static IYourTestClass GetTestClass()
        {
            return new TestFunctions();
        }
    }
