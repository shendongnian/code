    public class Banana : ICloneable
    {
        public Banana Clone()
        {
            ...
        }
        object ICloneable.Clone()
        {
            return Clone(); // Delegate to the more strongly-typed method
        }
    }
