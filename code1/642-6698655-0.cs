    static public class enumerationHelper
    {
        public class enumeratorHolder&lt;T&gt;
        {
            private T theEnumerator;
            public T GetEnumerator() { return theEnumerator; }
            public enumeratorHolder(T newEnumerator) { theEnumerator = newEnumerator;}
        }
        static enumeratorHolder&lt;T&gt; toEnumerable&lt;T&gt;(T theEnumerator) { return new enumeratorHolder&lt;T&gt;(theEnumerator); }
        private class IEnumeratorHolder&lt;T&gt;:IEnumerable&lt;T&gt;
        {
            private IEnumerator&lt;T&gt; theEnumerator;
            public IEnumerator&lt;T&gt; GetEnumerator() { return theEnumerator; }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return theEnumerator; }
            public IEnumeratorHolder(IEnumerator&lt;T&gt; newEnumerator) { theEnumerator = newEnumerator; }
        }
        static IEnumerable&lt;T&gt; toEnumerable&lt;T&gt;(IEnumerator&lt;T&gt; theEnumerator) { return new IEnumeratorHolder&lt;T&gt;(theEnumerator); }
    }
