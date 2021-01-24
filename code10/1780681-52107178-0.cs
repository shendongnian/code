    public class TestDbSqlQuery<T> : DbSqlQuery<T> where T : class
    {
        private readonly List<T> _innerList; 
        public TestDbSqlQuery(List<T> innerList)
        {
            _innerList = innerList;
        }
        public override IEnumerator<T> GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }
    }
