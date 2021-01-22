    public interface IIntelingenProvider
    {
        public Intelingen Item {get;}
    }
    public class Class1: Label, IIntelingenProvider
    {
        private Instellingen _Instellingen;
        public Intelingen Item { get { return _Instellingen; } }
    }
    public class Class2: Label, IIntelingenProvider
    {
        private Instellingen _Instellingen;
        public Intelingen Item { get {return _Instellingen; } }
    }
