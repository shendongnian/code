    public interface ICommon
    {
        int SomeProperty { get; set; }
    }
    public class MyType : ICommon
    {
        public int SomeProperty { get; set; }
    }
    public class MyOtherType : ICommon
    {
        public int SomeProperty { get; set; }
    }
    public class ClassWithMethod
    {
        public static List<T> DoSomethingSimple<T>(List<T> myTypes)
            where T : ICommon
        {
            return myTypes.Where(myType => myType.SomeProperty.Equals(2)).ToList();
        }
    }
