    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyDictionary = System.Collections.Generic.Dictionary<int, string>;
    using MyKeyValue = System.Collections.Generic.KeyValuePair<int, string>;
    
    namespace TestEnumerator
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestingMyEnumeradorPlus()
            {
                var itens = new MyDictionary()
                {
                    { 1, "aaa" }, 
                    { 2, "bbb" }
                };
                var enumerator = new EnumeradorPlus<MyKeyValue>(itens.GetEnumerator());
                enumerator.MoveNext();
                Assert.IsFalse(enumerator.Ended);
                enumerator.MoveNext();
                Assert.IsFalse(enumerator.Ended);
                enumerator.MoveNext();
                Assert.IsTrue(enumerator.Ended);
            }
        }
    
        public class EnumeradorPlus<T> : IEnumerator<T>
        {
            private IEnumerator<T> _internal;
            private bool _hasEnded = false;
    
            public EnumeradorPlus(IEnumerator<T> enumerator)
            {
                _internal = enumerator;
            }
    
            public T Current
            {
                get { return _internal.Current; }
            }
    
            public void Dispose()
            {
                _internal.Dispose();
            }
    
            object System.Collections.IEnumerator.Current
            {
                get { return _internal.Current; }
            }
    
            public bool MoveNext()
            {
                bool moved = _internal.MoveNext();
                if (!moved)
                    _hasEnded = true;
                return moved;
            }
    
            public void Reset()
            {
                _internal.Reset();
                _hasEnded = false;
            }
    
            public bool Ended
            {
                get { return _hasEnded; }
            }
        }
    }
