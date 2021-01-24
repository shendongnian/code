    public void Foo(int z)
    {
        A tmp = MyVar; // Creates a copy
        tmp.Update(z);
        _secondVar.Update(z);
    }
