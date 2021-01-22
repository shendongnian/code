    class Record : IPEndPoint, IComparable<Record>
    {
        internal long Offset { get; set; }
        public bool Deleted  { get; internal set; }
        public Record() : base(0, 0)
        { 
            Offset = -1;
            Deleted = false;
        }
        public int CompareTo(Record other)
        {
            if (this.Address == other.Address && this.Address == other.Address )
            {
                return 0;
            }
            else if (this.Address == other.Address)
            {
                return this.Port.CompareTo(other.Port);
            }
            else
            {
                return 
                  BitConverter.ToInt32(this.Address.GetAddressBytes(), 0).CompareTo(
                  BitConverter.ToInt32(other.Address.GetAddressBytes(), 0));
            }
        }
    }
