    [XmlType("test")]
    public class TestClass
    {
        private int _A;
        private int? _B;
        public TestClass()
            : this(0)
        {
        }
        public TestClass(int a)
        {
            _A = a;
        }
        [XmlAttribute("a")]
        public int A
        {
            get { return _A; }
            set { _A = value; _B = null; }
        }
        [XmlIgnore]
        public int B
        {
            get { if (_B == null) Recalculate(); return _B; }
            set { _B = value; }
        }
        private void Recalculate()
        {
            _B = _A + 1;
        }
    }
