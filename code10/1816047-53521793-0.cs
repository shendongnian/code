    public class SlotComparer : IEqualityComparer<Slot>
    {
        public bool Equals(Slot x, Slot y)
        {
            return x.Start.Equals(y.Start) 
                   && x.End.Equals(y.End);
        }
        public int GetHashCode(Slot slot)
        {
            return (slot.Start.ToLongDateString() 
                    + slot.End.ToLongDateString()).GetHashCode();
        }
    }
