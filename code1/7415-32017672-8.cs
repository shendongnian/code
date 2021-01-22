    public class BetterBaseClass
    {
        protected string state;
        public BetterBaseClass()
        {
            this.state = "BetterBaseClass";
            this.Initialize();
        }
        public void Initialize()
        {
            this.DisplayState();
        }
        public virtual void DisplayState()
        {
        }
    }
    public class DerivedFromBetter : BetterBaseClass
    {
        public DerivedFromBetter()
        {
            this.state = "DerivedFromBetter";
        }
        public override void DisplayState()
        {
            Console.WriteLine(this.state);
        }
    }
