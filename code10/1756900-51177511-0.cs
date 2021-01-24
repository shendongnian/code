    public class Header : IComparable
    {
        public long CombinedIndex { get; private set; }
        public int Key { get; set; } //Unique
        public bool IsRequired { get; set; }// True or false
        public DateTime? AvailableDate { get; set; } // null or date value
        public int Index { get; set; } // a number and can be same among other Header 
        public void CalculateCombinedIndex()
        {
            CombinedIndex = Key + (IsRequired ? 0 : 1) + Index + (AvailableDate ?? DateTime.MaxValue).Ticks;
        }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Header otherHeader = obj as Header;
            if (otherHeader != null)
            {
                if (this.IsRequired && !otherHeader.IsRequired)
                    return 1;
                if (!this.IsRequired && otherHeader.IsRequired)
                    return -1;
                if (this.Index > otherHeader.Index)
                    return 1;
                if (this.Index < otherHeader.Index)
                    return -1;
                //// ....
                return 0;
            }
            else
                throw new ArgumentException("Object is not a Temperature");
        }
    }
