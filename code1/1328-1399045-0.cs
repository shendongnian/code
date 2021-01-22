    public class Outer
    {
        private int Value { get; set; }
        public class Inner
        {
            protected void ModifyOuterMember(Outer outer, int value)
            {
                outer.Value = value;
            }
        }
    }
