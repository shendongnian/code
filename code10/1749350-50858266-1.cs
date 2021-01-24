    public enum TypeA { }
    public enum TypeB { }
    public enum TypeC { }
    public interface I<T> where T : struct
    {
        DateTime Date { get; set; }
        long? Value { get; set; }
        T Type { get; set; }
    }
    public class A : I<TypeA>
    {
        DateTime Date { get; set; }
        long? Value { get; set; }
        public TypeA Type { get; set; }
    }
    public class B : I<TypeB>
    {
        DateTime Date { get; set; }
        long? Value { get; set; }
        public TypeB Type { get; set; }
    }
    public class C : I<TypeC>
    {
        DateTime Date { get; set; }
        long? Value { get; set; }
        public TypeC Type { get; set; }
    }
