    public class Base
    {
        public struct MyStruct
        {
            public static int x = 100;
            public static int XX()
            {
                return 200;
            }
        }
    }
    public class Derived : Base
    {
        public void test()
        {
            int x = Derived.MyStruct.x;
            int XX = Derived.MyStruct.XX();
        }
    }
