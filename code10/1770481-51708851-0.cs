    public class FeeList : ICollection<IndividualFee>
    {
        private readonly List<IndividualFee> _list = new List<IndividualFee>();
        public int Count => _list.Count;
        public bool IsReadOnly => false;
        public void Add(IndividualFee item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (item.MaxValue < item.MinValue)
                throw new ArgumentException("Overlaps", nameof(item));
            if (_list.Count > 0 && item.MinValue < _list[_list.Count - 1].MaxValue)
                throw new ArgumentException("Overlaps", nameof(item));
        }
        public void Clear() => _list.Clear();
        public bool Contains(IndividualFee item) => _list.Contains(item);
        public void CopyTo(IndividualFee[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);
        public IEnumerator<IndividualFee> GetEnumerator() => _list.GetEnumerator();
        public bool Remove(IndividualFee item) => _list.Remove(item);
        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
    }
