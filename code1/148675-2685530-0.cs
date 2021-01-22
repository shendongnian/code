    public class RoundRobinIndex
    {
        volatile int index = 0;
        int count;
        public int Next
        {
            get
            {
                if (index == count)
                {
                    index = 0;
                } 
                return index++;
            }
        }
        public RoundRobinIndex(int countArg)
        {
            count = countArg;
        }
    }
