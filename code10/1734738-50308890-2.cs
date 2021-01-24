    public class A
    {
        public string S { get; set; } = "A";
    }
    public class B : A
    {
        public B() => S = "B";
    }
