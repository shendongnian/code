    public class BadBaseClass
    {
        protected string state;
        public BadBaseClass()
        {
            this.state = "BadBaseClass";
            this.DisplayState();
        }
        public virtual void DisplayState()
        {
        }
    }
    public class DerivedFromBad : BadBaseClass
    {
        public DerivedFromBad()
        {
            this.state = "DerivedFromBad";
        }
        public override void DisplayState()
        {   
            Console.WriteLine(this.state);
        }
    }
