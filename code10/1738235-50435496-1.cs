    public class CProperty
    {
        public CProperty(string name, Func<CProperty, Func<object>> get, Func<CProperty, Action<object>> set)
        {
            this.name = name;
            this.get = get(this);
            this.set = set(this);
        }
        private string name;
        public Func<object> get;
        public Action<object> set;
        public object value;
    }   
    var properties = new CProperty[]
    {
        new CProperty(
            "name1",
            cp => new Func<object>(() => cp.value),
            cp => new Action<object>((v) => cp.value = v)
        ),
    };
