    public void myF1(int a, int b, int c, int d)
    {
         internalF(a, b, { someelse1(c, d); }); 
    }
    public void myF2 (int a, int b, int c, Stream d)
    {
         internalF(a, b, { someelse2(c, d); });
    }
    private void internalF (int a, int b, Action action)
    {
        // dostuff
        action();
        // dostuff2
    }
