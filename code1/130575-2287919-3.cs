    int Times2(int a)
    {
        return a * 2;
    }
    
    void TheresNoDifferenceHere()
    {
        checked { Times2(int.MaxValue); }
        Times2(int.MaxValue);
    }
