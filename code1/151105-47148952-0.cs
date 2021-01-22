    public class Outer
    {
        public class Nested
        {
            readonly Outer Outer;
            public Nested(Outer outer /* , parameters */)
            {
                Outer = outer;
                //implementation...
            }
        
            //implementation...
        }
        public Nested GetNested(/* parameters */) => new Nested(this /* , parameters */);
    }
