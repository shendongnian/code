    public class Language
    {
        private string _name;
        private string _code;
        public Language(string name, string code)
        {
            _name = name;
            _code = code;
        }
        public string Name { get { return _name; }  }
        public string Code { get { return _code; } }
        public override void ToString()
        {
            return _name;
        }
    }
