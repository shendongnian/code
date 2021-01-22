        public static int GetSomething&lt;T&gt;(T enumerator) where T : IEnumerator&lt;int&gt;
        {
            T enumerator2 = enumerator;
            enumerator.MoveNext();
            enumerator2.MoveNext();
            return enumerator2.Current;
        }
