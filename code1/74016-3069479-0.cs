    public Foo (public float f) {
        Contracts.Require(f > 0);
    }
    public Foo (int i)
        : this ((float)i)
    {
        Contracts.Require(i > 0);
    }
