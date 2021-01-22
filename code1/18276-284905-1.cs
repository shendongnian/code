    public Foo(int x, int y)
    {
        this.x = x;
        this.y = y;
        precomputedValue = x * y;
    }
    private static int DefaultY
    {
        get { return DateTime.Now.Minute; }
    }
    public Foo(int x) : this(x, DefaultY)
    {
    }
    public Foo() : this(1, DefaultY)
    {
    }
