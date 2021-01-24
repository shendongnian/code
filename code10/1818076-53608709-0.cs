    public class Example : IExample
    {
        public int Property { get; set; } //// This causes error, too.
    }
    public interface IExample
    {
        int Property { get; }
    }
