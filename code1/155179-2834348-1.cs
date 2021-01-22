    public static class ArrayTableHelper {
        public static IEnumerable<IList<T>> GetRows<T>(this T[,] table) {
            for (int i = 0; i < table.GetLength(0); ++i)
                yield return new ArrayTableRow<T>(table, i);
        }
        private class ArrayTableRow<T> : IList<T> {
            private readonly T[,] _table;
            private readonly int _count;
            private readonly int _rowIndex;
            public ArrayTableRow(T[,] table, int rowIndex) {
                if (table == null)
                    throw new ArgumentNullException("table");
                if (rowIndex < 0 || rowIndex >= table.GetLength(0))
                    throw new ArgumentOutOfRangeException("rowIndex");
                _table = table;
                _count = _table.GetLength(1);
                _rowIndex = rowIndex;
            }
            // I didn't implement the setter below,
            // but you easily COULD (and then set IsReadOnly to false?)
            public T this[int index] {
                get { return _table[_rowIndex, index]; }
                set { throw new NotImplementedException(); }
            }
            public int Count {
                get { return _count; }
            }
            bool ICollection<T>.IsReadOnly {
                get { return true; }
            }
            public IEnumerator<T> GetEnumerator() {
                for (int i = 0; i < _count; ++i)
                    yield return this[i];
            }
            
            // omitted remaining IList<T> members for brevity;
            // you actually could implement IndexOf, Contains, etc.
            // quite easily, though
        }
    }
