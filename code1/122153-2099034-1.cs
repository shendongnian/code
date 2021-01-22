    public class CA
    {
        public CA(string s, List<int> numList)
        {
            // do some initialization
        }
    
        public CA(string s, int num) : this(s, num.ToList())
        {
        }
    }
