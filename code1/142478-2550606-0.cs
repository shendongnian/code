    void MyFunction1(out int p)
    {
        p = 5;
    }
    
    void MyFunction2(ref int p)
    {
        p = p + 1;
    }
    
    int x;
    MyFunction1(out x); // x == 5
    MyFunction2(ref x); // x == 6
