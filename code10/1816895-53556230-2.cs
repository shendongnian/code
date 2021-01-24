    public class TestBase
    {
        public virtual string ReadOnly => _testBaseReadOnly;
        public TestBase()
        {
            _testBaseReadOnly = "from base";
        }
        readonly string _testBaseReadOnly;
    }
