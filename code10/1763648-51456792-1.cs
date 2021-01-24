    public class manning
    {
        public static int i = 0;
        public manning() : this(i) 
        {
        }
        public manning(int i)
        {
            i++;
            Console.WriteLine(i);
        }
    }
