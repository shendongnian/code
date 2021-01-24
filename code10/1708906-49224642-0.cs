    public class BaseDTO
    {
        public string Type { get; set; }
        public string AValue { get; set; }
        public string BValue { get; set; }
        public string CValue { get; set; }
    }
    public class Base
    {
        public string Type { get; set; }
    }
    public class A : Base
    {
        public string AValue { get; set; }
    }
    public class B : Base
    {
        public string BValue { get; set; }
    }
    public class C : Base
    {
        public string CValue { get; set; }
    }
