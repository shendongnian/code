    class Program
    {
        public delegate void Del(int message);
        static void Main(string[] args)
        {
            Del handler = DelegateMethod;
            MethodWithCallback(handler);
        }
        public static void MethodWithCallback(Del callback)
        {
            for (int i = 0; i < 50; i++)
            {
                callback(i);
            
            }
                
        }
        public static void DelegateMethod(int primaryCounter)
        {
            System.Console.WriteLine(primaryCounter);
        }
    }
}
 
