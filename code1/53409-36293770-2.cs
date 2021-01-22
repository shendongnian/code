    public Test(bool a, int b, string c)
        : this(a, b)
    {
        this.C = c;
    }
    private Test(bool a, int b)
    {
        this.A = a;
        this.B = b;
    }
