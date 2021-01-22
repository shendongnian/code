    [Test]
    public void Should_Do_Stuff()
    {
        MyClass myObject = new MyClass();
        DataSet ds = myObject.ExampleMethod( 1, "string", ht );
    
        Assert.AreEqual( ds.Tables[0].Rows.Count, ht.Count );
        Assert.AreEqual( ht["key1"], ds.Tables[0].Rows[0][0].ToString() );
        Assert.AreEqual( ht["key1"], ds.Tables[0].Rows[0][1].ToString() );
    }
