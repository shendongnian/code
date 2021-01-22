    interface IReadOnly
    {
        int Attr { get; }
    }
    interface IWriteOnly
    {
        int Attr { set; }
    }
    interface I : IReadOnly, IWriteOnly
    {
    }
    class CReadOnly : IReadOnly
    {
        protected int _Attr;
        public int Attr
        {
            get { return _Attr; }
        }
    }
    class C : CReadOnly, I
    {
        public int Attr
        {
            get { return base.Attr; }
            set { _Attr = value; }
        }
    }
