        [TestCase(typeof(MyClass), "SomeResponse")]
        public void TestWrapper(Type t, string s)
        {
            typeof(MyClassUnderTest).GetMethod("MyMethod_GenericCall_MakesGenericCall").MakeGenericMethod(t).Invoke(null, new [] { s });
        }
