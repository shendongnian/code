    public class A
    {
        public int Id
        {
            get;
            set;
        }
    }
    public class B : A
    {
        public new int Id //<-- new is used
        {
            get;
            set;
        }
    }
