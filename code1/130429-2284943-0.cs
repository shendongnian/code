    [Test]
    public void TestUsing()
    {
        bool innerDisposed = false;
        using (var conn = new SqlConnection())
        {
            var conn2 = new SqlConnection();
            conn2.Disposed += (sender, e) => { innerDisposed = true; };
        }
    
        Assert.False(innerDisposed); // not disposed
    }
    
    [Test]
    public void TestUsing2()
    {
        bool innerDisposed = false;
        using (SqlConnection conn = new SqlConnection(), conn2 = new SqlConnection())
        {
            conn2.Disposed += (sender, e) => { innerDisposed = true; };
        }
        Assert.True(innerDisposed); // disposed, of course
    }
