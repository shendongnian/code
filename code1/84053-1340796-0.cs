    public abstract class AbstractClass : IBase
    {
        public override string ToString()
        {
            return "I am abstract";
        }
    
        public abstract string Property { get; }
    }
