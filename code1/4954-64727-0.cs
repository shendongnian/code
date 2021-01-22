    public void Foo(ref int value) { value = 12 }
    public void Bar()
    {
        int val = 3;
        Foo(ref val);
        // val == 12
    }
