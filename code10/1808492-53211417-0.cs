        static void Main(string[] args)
        {
            MODE Mode = MODE.TALKING; //Whatever value;
            int index = (int)Mode;
            index = ++index % 3;
            Mode = (MODE)index;
            Console.WriteLine("Mode value {0} ; index {1}", Mode, index );
            Console.ReadKey();
        }
