    public interface IPet {string GetNoise(); int CountLegs(); void Walk();}
    public abstract class Pet : IPet
    {
        public string Name {get; set;}
        public abstract string GetNoise(); // These must be here
        public abstract int CountLegs();
        public abstract void Walk();
    }
