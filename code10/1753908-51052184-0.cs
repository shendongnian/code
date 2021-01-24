    public interface IObjectWithTimer : IDisposable
    {
        void DoSomething();
    }
    public class ObjectWithTimer : IObjectWithTimer
    {
        // ...
    }
 
    public class ClassUnderTest
    { 
        public ClassUnderTest(IObjectWithTimer timer)
        {
            // ...
        }
        public void ThisShouldCallDisposeOnTimer()
        {
            // ...
        }
    }
