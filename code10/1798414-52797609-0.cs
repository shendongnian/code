    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Foo
    {
        [JsonConstructor]
        private Foo()
        { }
        private Foo(int x, bool asAList = false)
        {
            if (asAList)
                Baz = new List<int> { x };
            else
                Bar = x;
        }
        public static JObject Get(int x, bool asAList = false)
        {
            Foo foo = new Foo(x, asAList);
            return JObject.FromObject(foo);
        }
        [JsonProperty(PropertyName = "qwerty", NullValueHandling = NullValueHandling.Ignore)]
        private JToken Qwerty
        {
            get
            {
                return Bar.HasValue ? JToken.FromObject(Bar) : Baz != null ? JToken.FromObject(Baz) : null;
            }
            set
            {
                if (value != null && value.Type == JTokenType.Array)
                    Baz = value?.ToObject<List<int>>();
                else
                    Bar = value?.ToObject<int?>();
            }
        }
        public int? Bar { get; set; }
        public List<int> Baz { get; set; }
    }
