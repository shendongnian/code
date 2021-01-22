    CTest CTest = new CTest();
    Type t = CTest.GetType();
    FieldInfo p = t.GetField("test");
    CTest.test = "hello";
    string test = (string)p.GetValue(CTest);
    Console.WriteLine(CTest.GetType().FullName);
    Console.ReadLine();     
