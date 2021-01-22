    public interface IProcessor
    {
        void Process( IThingToProcess p ); // Will call p.ProcessMe()
        void Process( ThingToProcess1 concreteP ); // Called back from ThingToProcess1.ProcessMe
    }
    public interface IThingToProcess
    {
         void ProcessMe( IProcessor p );
    }
    public class ThingToProcess1 : IThingToProcess
    {
        public void ProcessMe( IProcessor p ) { p.Process( this ); }
    }
