    public class Example : ExampleBase
    {
        public override int Property { get; set; } //// This causes error.
        //// public int Property { get; private set; } //// This causes error, too.
    }
    
    public interface IExample
    {
        int Property { get; }
    }
    
    public abstract class ExampleBase
    {
        public abstract int Property { get; }
    }
