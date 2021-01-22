    public class A
    {
        private SafeList<string> _list = new SafeList<string>();
        public IReadOnlyList<string>
        {
            get { return _list; }
        }
    }
