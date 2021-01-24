    public class Test
    {
        public void Generate_Scentence()
        {
            var new1 = set_values("test", new SomeTypeOfVariable());
            var new2 = set_values("test2", "test2");
            var new3 = set_values("test3", 48584);
            var new4 = set_values("test4", 4.4f);
            var new5 = set_values("test5", new CustomClass());
            //etc etc
        }
        public Answer<TData> set_values<TData>(string t, TData v)
        {
            var a = new Answer<TData>();
            a.Read = t;
            a.Val = v;
            return a;
        }
    }
    public struct Answer<TData>
    {
        public string Read { get; set; }
        public TData Val { get; set; }
    }
    public class SomeTypeOfVariable { }
    public class CustomClass { }
