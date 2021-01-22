        static void Main()
        {
      
            if (x | y)
                Console.WriteLine("Get");
            Console.WriteLine("Yes");
            if (x || y)
                Console.WriteLine("Back");
            Console.ReadLine();
        }
        static bool x
        {
            get { Console.Write("Hey");  return true; }
        }
        static bool y
        {
            get { Console.Write("Jude"); return false; }
        }
