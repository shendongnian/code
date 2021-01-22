    class Program
    {
        static void Main(string[] args)
        {
            
            string csv = "Nizam, Babu, Arun,James,Neal";
            
            string[] split = csv.Split(new char[] {',',' '});
            foreach(string s in split)
            {
                if (s.Trim() != "")
                    Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
}
            
