    public class CProperty
    {
        public CProperty(string name, Func<CProperty, object> get, Action<CProperty, object> set)
        {
            this.name = name;
            this.get = get;
            this.set = set;
        }
        private string name;
        public Func<CProperty, object> get;
        public Action<CProperty, object> set;
        public object value;
    }
    var properties = new CProperty[]
    {
        new CProperty(
            "name1",
            new Func<CProperty, object>(cp => cp.value),
            new Action<CProperty, object>((cp, v) => cp.value = v)
        ),
    };
