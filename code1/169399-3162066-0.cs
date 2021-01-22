    [Obsolete("Backing field should not be used outside of property")]
    private object _foo;
    public object Foo
    {
        #pragma warning disable 612, 618
        get { return _foo; }
        set
        {
            _foo = value;
            OnFooChanged(EventArgs.Empty);
        }
        #pragma warning restore 612, 618
    }
