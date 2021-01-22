    private readonly List<SomeOtherClass> _items;
    public WhatClass()
    {
        _items = new List<SomeOtherClass>();
        this.Items = _items.AsReadOnly();
    }
    public ReadOnlyCollection<SomeOtherClass> Items { get; private set; }
