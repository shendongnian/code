    [TestFixture]
    public class MemoizerTest
    {
        [Test]
        public void MemoizationWorksOnFuncs()
        {
            int counter = 0;
            Func<int, int> f = x => counter += x;
            Assert.That(this.Memoized(1, f), Is.EqualTo(1));
            Assert.That(this.Memoized(2, f), Is.EqualTo(3));
            Assert.That(this.Memoized(2, f), Is.EqualTo(3));
            Assert.That(this.Memoized(1, f), Is.EqualTo(1));
        }
        private class MemoizedTest
        {
            private int _counter = 0;
            public int Method(int p)
                => this.Memoized(p, x => { return _counter += x; });
        }
        [Test]
        public void MemoizationWorksOnInstances()
        {
            var obj1 = new MemoizedTest();
            Assert.That(obj1.Method(5), Is.EqualTo(5));
            Assert.That(obj1.Method(4), Is.EqualTo(9));
            Assert.That(obj1.Method(5), Is.EqualTo(5));
            Assert.That(obj1.Method(1), Is.EqualTo(10));
            Assert.That(obj1.Method(4), Is.EqualTo(9));
            obj1 = new MemoizedTest();
            Assert.That(obj1.Method(5), Is.EqualTo(5));
            Assert.That(obj1.Method(4), Is.EqualTo(9));
            Assert.That(obj1.Method(5), Is.EqualTo(5));
            Assert.That(obj1.Method(1), Is.EqualTo(10));
            Assert.That(obj1.Method(4), Is.EqualTo(9));
        }
        [Test]
        [Ignore("This test passes only when compiled in Release mode")]
        public void WeakMemoizationCacheIsCleared()
        {
            var obj1 = new MemoizedTest();
            var r1 = obj1.Method(5);
            MemoizerExtension._weakCache.TryGetValue(obj1, out var cache);
            var weakRefToCache = new WeakReference(cache);
            cache = null;
            GC.Collect(2);
            obj1 = null;
            GC.Collect();
            GC.Collect();
            var msg = weakRefToCache.TrackResurrection;
            Assert.That(weakRefToCache.IsAlive, Is.False, "The weak reference should be dead.");
            Assert.That(r1, Is.EqualTo(5));
        }
    }
