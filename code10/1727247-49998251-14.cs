    public class RangeList : IEnumerable<Range>
    {
        private List<Range> ranges = new List<Range>();
        
        public void Add(Range range)
        {
            this.ranges.Add(range);
        }
        
        public IEnumerator<Range> GetEnumerator()
        {
            return this.ranges.GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator(){
            return this.GetEnumerator();
        }
    }
