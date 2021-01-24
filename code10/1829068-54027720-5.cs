    [TestClass]
    public class ReflectionExtensionTests
    {
        [TestMethod]
        public void DetectsIndexer()
        {
            var dict = new Dictionary<string, string>() {
                {"",""}
            };
            Expression<Func<string>> expr = () => dict[""];
            var method = (expr.Body as MethodCallExpression).Method;
            Assert.IsTrue(method.IsIndexerPropertyMethod());
        }
        [TestMethod]
        public void DetectsNotIndexer()
        {
            var dict = new Dictionary<string, string>() {
                {"",""}
            };
            Expression<Action<string, string>> expr = (s, s1) => dict.Add(s, s1);
            var method = (expr.Body as MethodCallExpression).Method;
            Assert.IsFalse(method.IsIndexerPropertyMethod());
        }
        [TestMethod]
        public void DetectsRenamedIndexer()
        {
            var myClass = new ClassWithRenamedIndexer();
            Expression<Func<int>> expr = () => myClass[2];
            var method = (expr.Body as MethodCallExpression).Method;
            Assert.IsTrue(method.IsIndexerPropertyMethod());
        }
        class ClassWithRenamedIndexer
        {
            [IndexerName("blarg")]
            public int this[int index]    // Indexer declaration  
            {
                get { return 1; }
            }
        }
    }
