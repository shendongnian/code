    public Test { public static void TestMethod(int num, ref string str) { } }
    typeof(Test).GetMethod("TestMethod"); // works
    typeof(Test).GetMethod("TestMethod", BindingFlags.Static); // doesn't work
    typeof(Test).GetMethod("TestMethod", BindingFlags.Static
                                         | BindingFlags.Public); // works
