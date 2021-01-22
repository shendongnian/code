    public class NumRange
    {
        public int ExclusiveLowerBound { get; private set; }
        public int ExclusiveUpperBound { get; private set; }
    
        public int Size
        {
            get
            {
                return ExclusiveUpperBound - ExclusiveLowerBound;
            }
        }
    
        public NumRange(int boundary1, int boundary2)
        {
            ExclusiveLowerBound = Math.Min(boundary1, boundary2);
            ExclusiveUpperBound = Math.Max(boundary1, boundary2);
        }
    
        public bool Contains(int num)
        {
            return num > ExclusiveLowerBound && num < ExclusiveUpperBound;
        }
    
    }
