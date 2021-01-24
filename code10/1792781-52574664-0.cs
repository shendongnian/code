    public class FlightInfoList : IList<FlightInfo>
    {
        private readonly List<FlightInfo> _flightInfos = new List<FlightInfo>();
        public IEnumerator<FlightInfo> GetEnumerator()
        {
            return _flightInfos.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(FlightInfo item)
        {
            if (_flightInfos.Any(flightInfo => flightInfo.Equals(item)))
            {
                throw new Exception("Cannot add duplicated values!");
            }
            _flightInfos.Add(item);
        }
        public void Clear()
        {
            _flightInfos.Clear();
        }
        public bool Contains(FlightInfo item)
        {
            return _flightInfos.Contains(item);
        }
        public void CopyTo(FlightInfo[] array, int arrayIndex)
        {
            _flightInfos.CopyTo(array, arrayIndex);
        }
        public bool Remove(FlightInfo item)
        {
            return _flightInfos.Remove(item);
        }
        public int Count => _flightInfos.Count;
        public bool IsReadOnly => false;
        public int IndexOf(FlightInfo item)
        {
            return _flightInfos.IndexOf(item);
        }
        public void Insert(int index, FlightInfo item)
        {
            _flightInfos.Insert(index, item);
        }
        public void RemoveAt(int index)
        {
            _flightInfos.RemoveAt(index);
        }
        public FlightInfo this[int index]
        {
            get => _flightInfos[index];
            set => _flightInfos[index] = value;
        }
    }
