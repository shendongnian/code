    public static class EnumeratorExtensions
    {
        /// <summary>
        /// "Clones" the specified <see cref="IEnumerator{T}"/> by wrapping it inside N new
        /// <see cref="IEnumerator{T}"/> instances, each can be advanced separately.
        /// See remarks for more information.
        /// </summary>
        /// <typeparam name="T">
        /// The type of elements the <paramref name="enumerator"/> produces.
        /// </typeparam>
        /// <param name="enumerator">
        /// The <see cref="IEnumerator{T}"/> to "clone".
        /// </param>
        /// <param name="clones">
        /// The number of "clones" to produce.
        /// </param>
        /// <returns>
        /// An array of "cloned" <see cref="IEnumerator[T}"/> instances.
        /// </returns>
        /// <remarks>
        /// <para>The cloning process works by producing N new <see cref="IEnumerator{T}"/> instances.</para>
        /// <para>Each <see cref="IEnumerator{T}"/> instance can be advanced separately, over the same
        /// items.</para>
        /// <para>The original <paramref name="enumerator"/> will be lazily evaluated on demand.</para>
        /// <para>If one enumerator advances far beyond the others, the items it has produced will be kept
        /// in memory until all cloned enumerators advanced past them, or they are disposed of.</para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// <para><paramref name="enumerator"/> is <c>null</c>.</para>
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para><paramref name="clones"/> is less than 2.</para>
        /// </exception>
        public static IEnumerator<T>[] Clone<T>(this IEnumerator<T> enumerator, Int32 clones)
        {
            #region Parameter Validation
            if (Object.ReferenceEquals(null, enumerator))
                throw new ArgumentNullException("enumerator");
            if (clones < 2)
                throw new ArgumentOutOfRangeException("clones");
            #endregion
            ClonedEnumerator<T>.EnumeratorWrapper wrapper = new ClonedEnumerator<T>.EnumeratorWrapper
            {
                Enumerator = enumerator,
                Clones = clones
            };
            ClonedEnumerator<T>.Node node = new ClonedEnumerator<T>.Node
            {
                Value = enumerator.Current,
                Next = null
            };
            IEnumerator<T>[] result = new IEnumerator<T>[clones];
            for (Int32 index = 0; index < clones; index++)
                result[index] = new ClonedEnumerator<T>(wrapper, node);
            return result;
        }
    }
    internal class ClonedEnumerator<T> : IEnumerator<T>, IDisposable
    {
        public class EnumeratorWrapper
        {
            public Int32 Clones { get; set; }
            public IEnumerator<T> Enumerator { get; set; }
        }
        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
        }
        private Node _Node;
        private EnumeratorWrapper _Enumerator;
        public ClonedEnumerator(EnumeratorWrapper enumerator, Node firstNode)
        {
            _Enumerator = enumerator;
            _Node = firstNode;
        }
        public void Dispose()
        {
            _Enumerator.Clones--;
            if (_Enumerator.Clones == 0)
            {
                _Enumerator.Enumerator.Dispose();
                _Enumerator.Enumerator = null;
            }
        }
        public T Current
        {
            get
            {
                return _Node.Value;
            }
        }
        Object System.Collections.IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public Boolean MoveNext()
        {
            if (_Node.Next != null)
            {
                _Node = _Node.Next;
                return true;
            }
            if (_Enumerator.Enumerator.MoveNext())
            {
                _Node.Next = new Node
                {
                    Value = _Enumerator.Enumerator.Current,
                    Next = null
                };
                _Node = _Node.Next;
                return true;
            }
            return false;
        }
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
