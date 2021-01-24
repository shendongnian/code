    public static class Program
    {
        private static int something;
        public static void Main()
        {
            One();
  
            Console.Read();
        }
        private static void Three()
        {
            something = 3;
            Four();
        }
        private static void Four()
        {
            something = 4;
        }
        private static void Two()
        {
            something = 2;
            Three();
        }
        private static void One()
        {
            something = 1;
            Two();
        }
    }
