    public partial class Foo
    {
        private string _bar;
        
        private object[] _baz;
        public string Bar
        {
            get { return _bar; }
            set { _bar= value; }
        }
        [XmlArray("Baz")]
        [XmlArrayItem("Type1", typeof(Type1))]
        public object[] Baz
        {
            get { return _baz; }
            set { _baz= value; }
        }
    }
