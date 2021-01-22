    public class Log4NetContextProperty : IFixingRequired
    {
        private readonly Func<string> _getValue;
        public Log4NetContextProperty(Func<string> getValue)
        {
            _getValue = getValue;
        }
        public override string ToString()
        {
            return _getValue();
        }
        public object GetFixedObject()
        {
            return ToString();
        }
    }
