    public interface IProcessingMethod
    {
        void Process();
    }
    public class SequentialProcess : IProcessingMethod
    {
        public void Process( IProcessable obj )
        {
             do something sequentially with the obj
        }
    }
    public class ParallelProcess : IProcessingMethod
    {
        public void Process( IProcessable obj )
        {
            do something in parallel with the obj
        }
    }
    public interface IProcessable
    {
        void Process( IProcessingMethod method );
    }
    public class MyClass : IProcessable
    {
         public void Process( IProcessingMethod method )
         {
             method.Process( this );
         }
    }
    ...
    var obj = new MyClass();
    obj.Process( new SequentialProcess() );
