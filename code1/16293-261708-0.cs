    public enum MyEnum { A, B, C }
    public static class MyEnumExt
    {
        public static int Value(this MyEnum foo) { return (int)foo; }
        static void Main()
        {
            MyEnum val = MyEnum.A;
            int i = val.Value();
        }
    }
