    private int _foo;
    public int Foo
    {
        get { return _foo; }
        set
        {
            if (this.Site != null && this.Site.DesignMode)
                throw new InvalidOperationException();
            _foo = value;
        }
    }
