    public class A
    {
        internal A(string s)
        {
            PropSetByConstructor = s;
        }
        public string PropSetByConstructor { get; set; }
    }
    public class B : A
    {
        internal B(string s)
            : base(s)
        {
            PropSetByConstructor = "Set by B:" + s;
        }
    }
