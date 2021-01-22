    abstract public class X<T> where T : A
    {
        protected T myA;
        abstract public int MethodForX();
    }
    public class Y : X<B>
    {
        public Y()
        {
            myA = new B(); //B inherits from A
        }
        override public int MethodForX()
        {
            return myA.MethodForB(1);
        }
    }
