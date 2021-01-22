    //you may want to also use interfaces.
    interface IFather
    {
        int MyInt { get; set; }
    }
    public class Father : IFather
    {
        //defaulting the value of this property to 1
        private int myInt = 1;
        public virtual int MyInt
        {
            get { return myInt; }
            set { myInt = value; }
        }
    }
    public class Son : Father
    {
        public override int MyInt
        {
            get {
                //demonstrating that you can access base.properties
                //this will return 1 from the base class
                int baseInt = base.MyInt;
                //add 1 and return new value
                return baseInt + 1;
            }
            set
            {
                //sets the value of the property
                base.MyInt = value;
            }
        }
    }
