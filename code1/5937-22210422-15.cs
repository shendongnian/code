    public class C : B
    {
        private int _x;
        public override int X
        {
            get { return _x; }
            set { _x = value; }   //  Won't compile
        }
    }
