        public static class HardCast<T>
        {
            public static T Cast(object o)
            { return (T)o; }
        }
        public static class SoftCast
        {
            public static T Cast<T>(object o)
            { return (T)o; }
        }
        static void Main(string[] args)
        {
            object o = "hi!";
            string s;
            s = HardCast<string>.Cast(o);
            s = SoftCast.Cast<string>(o);
        }
