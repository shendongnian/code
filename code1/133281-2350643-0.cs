    static void Main()
    {
        try
        {
            var direct = new Dictionary<string, string>();
            direct.Add("abc", "abc");
            direct.Add("def", "def");
            using (var iter = direct.GetEnumerator())
            {
                iter.MoveNext();
                Console.WriteLine(iter.Current.Value);
                direct["def"] = "DEF";
                iter.MoveNext();
                Console.WriteLine(iter.Current.Value);
            }
        }
        catch { Console.WriteLine("direct: BOOM"); }
        try
        {
            var indirect = new Dictionary<string, Wrapper<string>>();
            indirect.Add("abc", "abc");
            indirect.Add("def", "def");
            using (var iter = indirect.GetEnumerator())
            {
                iter.MoveNext();
                Console.WriteLine(iter.Current.Value);
                indirect["def"].Value = "DEF";
                iter.MoveNext();
                Console.WriteLine(iter.Current.Value);
            }
        } catch { Console.WriteLine("indirect: BOOM"); }
    }
    class Wrapper<T> where T : class {
        public T Value { get; set; }
        public static implicit operator Wrapper<T>(T value) {
            return new Wrapper<T> { Value = value};
        }
        public static implicit operator T (Wrapper<T> value) {
            return value.Value;
        }
        public override string ToString() {
            return Convert.ToString(Value);
        }
    }
