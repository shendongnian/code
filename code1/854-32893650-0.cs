        var method1 = typeof(MyClass).GetMethod("TestString1").GetMethodBody().GetILAsByteArray();
        var method2 = typeof(MyClass).GetMethod("TestString2").GetMethodBody().GetILAsByteArray();
        //...
        public string TestString1()
        {
            string str = "Hello World!";
            return str;
        }
        public string TestString2()
        {
            String str = "Hello World!";
            return str;
        }
