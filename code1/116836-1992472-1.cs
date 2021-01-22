    public void TestIt()
    {
        TheParent p = new TheParent
        {
            field1 = 5,
            field2 = "foo",
            field3 = 4.5,
            field4 = 3
        };
        TheChild c = p.CreateChild();
        Debug.Assert(c.field1 == p.field1);
        Debug.Assert(c.field2 == p.field2);
        Debug.Assert(c.field3 == p.field3);
    }
