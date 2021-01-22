    void Test1(string param)
    {
        param = "new value";
    }
    
    string s1 = "initial value";
    Test1(s1);
    // s1 == "initial value"
