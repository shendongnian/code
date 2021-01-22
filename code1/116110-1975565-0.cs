    static void Test(object[] args)
    {
      TestTarget((string)args[0], (int)args[1], (DateTime?)args[2]);
    }
    
    static void TestTarget(string s, int i, DateTime? dt){}
