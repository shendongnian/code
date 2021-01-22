    struct Bar { public int Val; }
    public void Foo()
    {
        Bar z;      // this is legal...
        z.Val = 5;
        Bar q = new Bar(5); // so is this...
        q.Val = 10;
    }
