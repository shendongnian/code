    public string Foo()
    {
        set {
            if (value == null)
                throw new ArgumentNullException("value");
            if (!value.Contains("bar"))
                throw new ArgumentException(@"value should contain ""bar""", "value");
            _foo = value;
        }
    }
