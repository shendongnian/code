    public enum MyEnum
    {
        Foo,
        Bar
    }
    public interface IDummy<EnumType>
    {
        void OneMethod(EnumType enumVar);
    }
    public class Dummy : IDummy<MyEnum>
    {
        public void OneMethod(MyEnum enumVar)
        {
            // Your code
        }
    }
