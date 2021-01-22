    [Test]
    public void Test()
    {
        Assert.Throws<NullReferenceException>( _TestBody );
    }
    
    private void _TestBody()
    {
        string test = null;
        test.Substring( 0, 4 );
    }
