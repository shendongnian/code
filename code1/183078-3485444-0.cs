    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    public class ImmutableList<T> : IList<T>, IEquatable<ImmutableList<T>>
    {
        #region Private data
        private readonly IList<T> _items;
        private readonly int _hashCode;
        #endregion
        #region Constructor
        public ImmutableList(IEnumerable<T> items)
        {
            _items = items.ToArray();
            _hashCode = ComputeHash();
        }
        #endregion
        #region Public members
        public ImmutableList<T> Add(T item)
        {
            return this
                    .Append(item)
                    .AsImmutable();
        }
        public ImmutableList<T> Remove(T item)
        {
            return this
                    .SkipFirst(it => object.Equals(it, item))
                    .AsImmutable();
        }
        public ImmutableList<T> Insert(int index, T item)
        {
            return this
                    .InsertAt(index, item)
                    .AsImmutable();
        }
        public ImmutableList<T> RemoveAt(int index)
        {
            return this
                    .SkipAt(index)
                    .AsImmutable();
        }
        public ImmutableList<T> Replace(int index, T item)
        {
            return this
                    .ReplaceAt(index, item)
                    .AsImmutable();
        }
        #endregion
        #region Interface implementations
        public int IndexOf(T item)
        {
            if (_items == null)
                return -1;
            return _items.IndexOf(item);
        }
        public bool Contains(T item)
        {
            if (_items == null)
                return false;
            return _items.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (_items == null)
                return;
            _items.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get
            {
                if (_items == null)
                    return 0;
                return _items.Count;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (_items == null)
                return Enumerable.Empty<T>().GetEnumerator();
            return _items.GetEnumerator();
        }
        public bool Equals(ImmutableList<T> other)
        {
            if (other == null || this._hashCode != other._hashCode)
                return false;
            return this.SequenceEqual(other);
        }
        #endregion
        #region Explicit interface implementations
        void IList<T>.Insert(int index, T item)
        {
            throw new InvalidOperationException();
        }
        void IList<T>.RemoveAt(int index)
        {
            throw new InvalidOperationException();
        }
        T IList<T>.this[int index]
        {
            get
            {
                if (_items == null)
                    throw new IndexOutOfRangeException();
                return _items[index];
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
        void ICollection<T>.Add(T item)
        {
            throw new InvalidOperationException();
        }
        void ICollection<T>.Clear()
        {
            throw new InvalidOperationException();
        }
        bool ICollection<T>.IsReadOnly
        {
            get { return true; }
        }
        bool ICollection<T>.Remove(T item)
        {
            throw new InvalidOperationException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj is ImmutableList<T>)
            {
                var other = (ImmutableList<T>)obj;
                return this.Equals(other);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return _hashCode;
        }
        #endregion
        #region Private methods
        private int ComputeHash()
        {
            if (_items == null)
                return 0;
            return _items
                .Aggregate(
                    983,
                    (hash, item) =>
                        item != null
                            ? 457 * hash ^ item.GetHashCode()
                            : hash);
        }
        #endregion
    }
