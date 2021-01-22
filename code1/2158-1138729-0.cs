    class MyStatic { public static int MyValue=0; }
    class Test<T> where T: MyStatic
    {
        public void TheTest() { T.MyValue++; }
    }
