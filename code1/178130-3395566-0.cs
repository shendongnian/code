    class Program
    {
        static void Main(string[] args)
        {
            string src = "a{b{c{d,e}f}g}h";
            int occurenceCount = 0;
            foreach (char ch in src)
            {
                if(ch == '{')
                {
                    occurenceCount++;
                }
            }
            Console.WriteLine("Enter a no. to remove block: ");
            int givenValue = 0;
            CheckValid(out givenValue);
            int removeCount = occurenceCount + 1 - givenValue;
            occurenceCount = 0;
            int startPos = 0;
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] == '{')
                {
                    occurenceCount++;
                }   
                if(occurenceCount == removeCount)
                {
                    startPos = i;
                    break;
                    //i value { of to be removed block
                }
            }
            int endPos = src.IndexOf('}', startPos);
            src = src.Remove(startPos,endPos);
            
            //index of }
            Console.WriteLine("after reved vale:" + src);
            Console.ReadKey();
        }
        public static void CheckValid(out int givenValue)
        {
            if (!int.TryParse(Console.ReadLine(), out givenValue))
            {
                Console.WriteLine("Enter a valid no. to remove block: ");
                CheckValid(out givenValue);
            }
        }
    }
}
