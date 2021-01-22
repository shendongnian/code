    internal class Set<TElement>
    {
        private int[] _buckets;
        private Slot[] _slots;
        private int _count;
        private int _freeList;
        private readonly IEqualityComparer<TElement> _comparer;
        public Set()
            : this(null)
        {
        }
        public Set(IEqualityComparer<TElement> comparer)
        {
            if (comparer == null)
                comparer = EqualityComparer<TElement>.Default;
            _comparer = comparer;
            _buckets = new int[7];
            _slots = new Slot[7];
            _freeList = -1;
        }
        public bool Add(TElement value)
        {
            return !Find(value, true);
        }
        public bool Contains(TElement value)
        {
            return Find(value, false);
        }
        public bool Remove(TElement value)
        {
            var hashCode = InternalGetHashCode(value);
            var index1 = hashCode % _buckets.Length;
            var index2 = -1;
            for (var index3 = _buckets[index1] - 1; index3 >= 0; index3 = _slots[index3].Next)
            {
                if (_slots[index3].HashCode == hashCode && _comparer.Equals(_slots[index3].Value, value))
                {
                    if (index2 < 0)
                        _buckets[index1] = _slots[index3].Next + 1;
                    else
                        _slots[index2].Next = _slots[index3].Next;
                    _slots[index3].HashCode = -1;
                    _slots[index3].Value = default(TElement);
                    _slots[index3].Next = _freeList;
                    _freeList = index3;
                    return true;
                }
                index2 = index3;
            }
            return false;
        }
        private bool Find(TElement value, bool add)
        {
            var hashCode = InternalGetHashCode(value);
            for (var index = _buckets[hashCode % _buckets.Length] - 1; index >= 0; index = _slots[index].Next)
            {
                if (_slots[index].HashCode == hashCode && _comparer.Equals(_slots[index].Value, value))
                    return true;
            }
            if (add)
            {
                int index1;
                if (_freeList >= 0)
                {
                    index1 = _freeList;
                    _freeList = _slots[index1].Next;
                }
                else
                {
                    if (_count == _slots.Length)
                        Resize();
                    index1 = _count;
                    ++_count;
                }
                int index2 = hashCode % _buckets.Length;
                _slots[index1].HashCode = hashCode;
                _slots[index1].Value = value;
                _slots[index1].Next = _buckets[index2] - 1;
                _buckets[index2] = index1 + 1;
            }
            return false;
        }
        private void Resize()
        {
            var length = checked(_count * 2 + 1);
            var numArray = new int[length];
            var slotArray = new Slot[length];
            Array.Copy(_slots, 0, slotArray, 0, _count);
            for (var index1 = 0; index1 < _count; ++index1)
            {
                int index2 = slotArray[index1].HashCode % length;
                slotArray[index1].Next = numArray[index2] - 1;
                numArray[index2] = index1 + 1;
            }
            _buckets = numArray;
            _slots = slotArray;
        }
        internal int InternalGetHashCode(TElement value)
        {
            if (value != null)
                return _comparer.GetHashCode(value) & int.MaxValue;
            return 0;
        }
        internal struct Slot
        {
            internal int HashCode;
            internal TElement Value;
            internal int Next;
        }
    }
