    public class NullB : B
    {
        public override C C
        {
            get { return new NullC(); }
        }
    }
