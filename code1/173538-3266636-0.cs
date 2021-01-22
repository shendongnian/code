    class SomeClass
    {
        MyType myObject;
        public SomeClass()
        {
            SomeOtherClass.MyFunction(out myObject);
        }
    }
    static class SomeOtherClass
    {
        public static void MyFunction(out MyType mType)
        {
            mType = new MyType();
            FieldInfo[] fInfo = mType.GetType().GetFields();
        }
    }
    class MyType
    {
        string Name;
    }
