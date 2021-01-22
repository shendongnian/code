    private FooThingy _foo;
    public FooThingy Foo
    {
        set 
        { 
            if (null == _foo) { _foo = value; }
            else  { throw new WhatEverThatFitsException(); }
        }
        get { return _foo; }
    }
