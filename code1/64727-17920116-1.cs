    class Program
    {
        static void Main(string[] args)
        {        
            List<int> list = new List<int>();
            int val;
            Random r;
            int IntialCount = 1;
            int count = 7 ;
            int maxRandomValue = 8;
    
            while (IntialCount <= count)
            {
                r = new Random();
                val = r.Next(maxRandomValue);
                if (!list.Contains(val))
                {
                    list.Add(val);
                    IntialCount++;
                }
    
            } 
        }
    }
