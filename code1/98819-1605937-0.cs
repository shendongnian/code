    public interface IThreadSafeEnumerator<T>
    {
        void Reset();
        bool TryMoveNext(out T value);
    }
    public class ThreadSafeUIntEnumerator : IThreadSafeEnumerator<uint>, IEnumerable<uint>
    {
        readonly object sync = new object();
        uint n;
        #region IThreadSafeEnumerator<uint> Members
        public void Reset()
        {
            lock (sync)
            {
                n = 0;
            }
        }
        public bool TryMoveNext(out uint value)
        {
            bool success = false;
            lock (sync)
            {
                if (n < 100)
                {
                    value = n++;
                    success = true;
                }
                else
                {
                    value = uint.MaxValue;
                }
            }
            return success;
        }
        #endregion
        #region IEnumerable<uint> Members
        public IEnumerator<uint> GetEnumerator()
        {
            //Reset(); // depends on what behaviour you want
            uint value;
            while (TryMoveNext(out value))
            {
                yield return value;
            }
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            //Reset(); // depends on what behaviour you want
            uint value;
            while (TryMoveNext(out value))
            {
                yield return value;
            }
        }
        #endregion
    }
