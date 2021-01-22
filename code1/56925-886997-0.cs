    public class ChildOne : Parent
    {
        public new int PropertyOne  // No Compiler Error
        {
            get { return base.PropertyOne; }
            set { base.PropertyOne = value; }
        }
        // PropertyTwo is not available to users of ChildOne
    }
    public class ChildTwo : Parent
    {
        // PropertyOne is not available to users of ChildTwo
        public new int PropertyTwo
        {
            get { return base.PropertyTwo; }
            set { base.PropertyTwo = value; }
        }
    }
