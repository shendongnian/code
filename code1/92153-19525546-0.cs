    public abstract class TheBase
    {
        public int Value
        {
            get;
            protected set;
        }
    }
    public class TheDerived : TheBase
    {
        public new int Value
        {
            get { return base.Value; }
            set { base.Value = value; }
        }
    }
