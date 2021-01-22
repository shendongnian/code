    private class DbDataReader : System.IDisposable
    {
        #region IDisposable Members
    
        public void Dispose() { }
    
        #endregion
    }
    private class DbQueryProvider
    {
        private DbDataReader _reader;
    
        public bool IsReaderDisposed { get { return _reader == null; } }
    
        public DbQueryProvider()
        {
            _reader = new DbDataReader();
        }
    
        public IEnumerable<int> Project(int numResults)
        {
            int i = 0;
            while (i < numResults)
            {
                yield return i++;
            }
            _reader.Dispose();
            _reader = null;
        }
    
        public IEnumerable<int> ProjectWithFinally(int numResults)
        {
            int i = 0;
            try
            {
                while (i < numResults)
                {
                    yield return i++;
                }
            }
            finally
            {
                _reader.Dispose();
                _reader = null;
            }
        }
    
    }
    
    [Test]
    public void YieldReturn_Returns_TrueForIsReaderDisposed()
    {
        const int numResults = 1;
        
        var qp1 = new DbQueryProvider();
        var q1 = qp1.Project(numResults);
        Assert.IsInstanceOf(typeof(int), q1.First());
    
        var qp2 = new DbQueryProvider();
        var q2 = qp2.Project(numResults);
        Assert.IsInstanceOf(typeof(int), q2.FirstOrDefault());
    
        var qp3 = new DbQueryProvider();
        var q3 = qp3.Project(numResults);
        Assert.IsInstanceOf(typeof(int), q3.Single());
    
        var qp4 = new DbQueryProvider();
        var q4 = qp4.Project(numResults);
        Assert.IsInstanceOf(typeof(int), q4.SingleOrDefault());
    
        Assert.IsTrue(qp1.IsReaderDisposed);
        Assert.IsTrue(qp2.IsReaderDisposed);
        Assert.IsTrue(qp3.IsReaderDisposed);
        Assert.IsTrue(qp4.IsReaderDisposed);
    }
    
    [Test]
    public void YieldReturnFinally_Returns_TrueForIsReaderDisposed()
    {
        const int numResults = 1;
    
        var qp1 = new DbQueryProvider();
        var q1 = qp1.ProjectWithFinally(numResults);
        Assert.IsInstanceOf(typeof(int), q1.First());
    
        var qp2 = new DbQueryProvider();
        var q2 = qp2.ProjectWithFinally(numResults);
        Assert.IsInstanceOf(typeof(int), q2.FirstOrDefault());
    
        var qp3 = new DbQueryProvider();
        var q3 = qp3.ProjectWithFinally(numResults);
        Assert.IsInstanceOf(typeof(int), q3.Single());
    
        var qp4 = new DbQueryProvider();
        var q4 = qp4.ProjectWithFinally(numResults);
        Assert.IsInstanceOf(typeof(int), q4.SingleOrDefault());
    
        Assert.IsTrue(qp1.IsReaderDisposed);
        Assert.IsTrue(qp2.IsReaderDisposed);
        Assert.IsTrue(qp3.IsReaderDisposed);
        Assert.IsTrue(qp4.IsReaderDisposed);
    }
