    public class NamedIndexProp
    {
        private MainClass _Owner;
        public NamedIndexProp(MainClass Owner) { _Owner = Owner;
        public DataType this[IndexType ndx]
        {
            get { return _Owner.Getter(ndx); }
            set { _Owner.Setter(ndx, value); }
        }
    }
    public MainClass
    {
        private NamedIndexProp _PropName;
        public MainClass()
        {
           _PropName = new NamedIndexProp(this);
        }
        public NamedIndexProp PropName { get { return _PropName; } }
        internal DataType getter(IndexType ndx)
        {
            return ...
        }
        internal void Setter(IndexType ndx, DataType value)
        {
           ... = value;
        }
    }
