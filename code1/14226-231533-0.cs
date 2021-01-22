    public class BaseNCounter
    {
        public char[] CharSet { get; set; }
        public int Power { get; set; }
    
        public BaseNCounter() { }
    
        public IEnumerable<string> Count() {
            long max = (long)Math.Pow((double)this.CharSet.Length, (double)this.Power);
            long[] counts = new long[this.Power];
            for(long i = 0; i < max; i++)
                yield return IncrementArray(ref counts, i);
        }
    
        public string IncrementArray(ref long[] counts, long count) {
            long temp = count;
            for (int i = this.Power - 1; i >= 0 ; i--) {
                long pow = (long)Math.Pow(this.CharSet.Length, i);
                counts[i] = temp / pow;
                temp = temp % pow;
            }
    
            StringBuilder sb = new StringBuilder();
            foreach (int c in counts) sb.Insert(0, this.CharSet[c]);
            return sb.ToString();
        }
    }
