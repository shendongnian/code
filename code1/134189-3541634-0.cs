    public class Banana : ICloneable
    {
        public Banana Clone() // Fails: this doesn't implement the interface
        {
            ...
        }
    }
