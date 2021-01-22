    public class SafeQueue<T>: Queue<T>
    {
        public SafeQueue() : base() { }
        public SafeQueue(int count) : base(count) { }
        public SafeQueue(IEnumerable<T> collection) : base(collection) { }
        public bool IsEmpty {get { return Count == 0; }}
        public new T Dequeue()
        {
            return IsEmpty ? default(T) : base.Dequeue();
        }
        public new T Peek()
        {
            return IsEmpty ? default(T) : base.Peek();
        }
    }
    [TestClass]
    public class SafeQueueTests
    {
        [TestMethod]
        public void SafeQueue_int_constructor_works()
        {
            var q = new SafeQueue<string>(5);
            Assert.IsNotNull(q);
            Assert.AreEqual(0, q.Count);
            q.Enqueue("a");
            Assert.AreEqual(1, q.Count);
            q.Enqueue("b");
            Assert.AreEqual(2, q.Count);
            q.Enqueue("c");
            Assert.AreEqual(3, q.Count);
            q.Enqueue("d");
            Assert.AreEqual(4, q.Count);
            q.Enqueue("e");
            Assert.AreEqual(5, q.Count);
            q.Enqueue("f");
            Assert.AreEqual(6, q.Count);
        }
        [TestMethod]
        public void SafeQueue_dequeue_works()
        {
            var q = new SafeQueue<string>();
            Assert.IsNotNull(q);
            Assert.AreEqual(0, q.Count);
            q.Enqueue("a");
            Assert.AreEqual(1, q.Count);
            q.Enqueue("b");
            Assert.AreEqual(2, q.Count);
            var result = q.Dequeue();
            Assert.AreEqual("a", result);
            result = q.Dequeue();
            Assert.AreEqual("b", result);
            result = q.Dequeue();
            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void SafeQueue_peek_works()
        {
            var q = new SafeQueue<string>();
            Assert.IsNotNull(q);
            Assert.AreEqual(0, q.Count);
            q.Enqueue("a");
            Assert.AreEqual(1, q.Count);
            var result = q.Peek();
            Assert.AreEqual("a", result);
            result = q.Dequeue();
            Assert.AreEqual("a", result);
            result = q.Dequeue();
            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void SafeQueue_isEmpty_works()
        {
            var q = new SafeQueue<string>();
            Assert.IsNotNull(q);
            Assert.AreEqual(0, q.Count);
            Assert.AreEqual(true, q.IsEmpty);
            q.Enqueue("content");
            Assert.AreEqual(false, q.IsEmpty);
            var result2 = q.Dequeue();
            Assert.AreEqual("content", result2);
            Assert.AreEqual(true, q.IsEmpty);
            result2 = q.Dequeue();
            Assert.AreEqual(true, q.IsEmpty);
            Assert.AreEqual(null, result2);
        }
        [TestMethod]
        public void SafeQueue_passedThroughQueueOperationContains_work()
        {
            var q = new SafeQueue<string>(5);
            Assert.IsNotNull(q);
            Assert.AreEqual(0, q.Count);
            q.Enqueue("a");
            Assert.AreEqual(1, q.Count);
            q.Enqueue("b");
            Assert.AreEqual(2, q.Count);
            q.Enqueue("c");
            Assert.AreEqual(3, q.Count);
            Assert.IsTrue(q.Contains("a"));
            Assert.IsFalse(q.Contains("asdfawe"));
            var outval = q.Dequeue();
            Assert.IsFalse(q.Contains("a"));
        }
        [TestMethod]
        public void SafeQueue_CantTellByDequeueIfQueueIsEmptyOrContainsNull()
        {
            var q = new SafeQueue<string>();
            Assert.IsNotNull(q);
            Assert.AreEqual(true, q.IsEmpty);
            q.Enqueue(null);
            Assert.AreEqual(false, q.IsEmpty);
            var result2 = q.Peek();
            Assert.AreEqual(null, result2);
            Assert.AreEqual(false, q.IsEmpty);
            result2 = q.Dequeue();
            Assert.AreEqual(true, q.IsEmpty);
            Assert.AreEqual(null, result2);
        }
    }
