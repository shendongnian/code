        public class AutoCompleteStringWithIdCollection : AutoCompleteStringCollection
    {
        private List<Guid> _idList = new List<Guid>();
        /*-- Properties --*/
        public Guid this[int index]
        {
            get
            {
                return _idList[index];
            }
        }
        public Guid this[string value]
        {
            get
            {
                int index = base.IndexOf(value);
                return _idList[index];
            }
        }
        /*-- Methods --*/
        public int Add(string value, Guid id)
        {
            int index = base.Add(value);
            _idList.Insert(index, id);
            return index;
        }
        public new void Remove(string value)
        {
            int index = base.IndexOf(value);
            if (index > -1)
            {
                base.RemoveAt(index);
                _idList.RemoveAt(index);
            }
        }
        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
            _idList.RemoveAt(index);
        }
        public new void Clear()
        {
            base.Clear();
            _idList.Clear();
        }
    }
