    public abstract class A
    {
        public string Code { get;set; }
    }
    public class B : A
    {
        public new string Code { get;set; }
        public string Title { get;set; }
    }
