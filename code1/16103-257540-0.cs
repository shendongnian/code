    try
    {
        obj.SetValueAt(-1, "foo");
        Assert.Fail("Expected exception");
    }
    catch (IndexOutOfRangeException)
    {
        // Expected
    }
    Assert.IsTrue(obj.IsValid());
