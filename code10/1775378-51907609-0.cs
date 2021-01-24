    class Program
    {
        public static List<string> testListInitialized;
        public static List<string> testListUninitialized;
        static void Main(string[] args)
        {
            testListInitialized = new List<string>();
            testListInitialized.Add("Test");
            Console.WriteLine("Checking testListInitialized...");
            CheckList(ref testListInitialized);
            Console.WriteLine("---------");
            Console.WriteLine("Checking testListUninitialized...");
            CheckList(ref testListUninitialized);
            Console.WriteLine("---------");
            Console.ReadKey();
        }
        static void CheckList(ref List<string> checkList)
        {
            if (checkList == null)
            {
                Console.WriteLine("List to check is null. Initializing.");
                checkList = new List<string>();
                return;
            }
            //Do other code here.
            Console.WriteLine("List to check is initialized.");
            return;
        }
    }
