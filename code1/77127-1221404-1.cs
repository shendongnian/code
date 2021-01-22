    public class Implementer : ISecondInterface
    {
        internal IFirstInterface First { get; private set; }
        IFirstInterface ISecondInterface.First { get { return First; } }
    }
