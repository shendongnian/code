    public int MyFunction(MyType t)
    {
       return MyMemoizableFunction(t.Value);
    }
    private int MyMemoizableFunction(int value)
    {
       return value + 1;
    }
