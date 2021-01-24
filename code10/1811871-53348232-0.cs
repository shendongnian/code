     static void Main(string[] args)
        {
            string s;
            string sReverse = "";
            int Length;
    
            Console.WriteLine("Say any word please: ");
            s = Console.ReadLine();
            Length = s.Length - 1;
    
            for (int i = Length; i >= 0; i--)
            {
                sReverse = sReverse + s[Length];
                Length--;
    
            }
    
            Console.WriteLine("{0}", sReverse);
            Console.ReadLine();
        }
