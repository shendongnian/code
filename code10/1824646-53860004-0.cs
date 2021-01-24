    internal class Program
    {
        private static string testString = "703.36,751.36,\"1,788.36\",887.37,891.37,\"1,850.37\",843.37,\"1,549,797.36\",818.36,749.36,705.36,0.00,\"18,979.70\",934.37";
        
        private static void Main(string[] args)
        {
            bool inQuote = false;
            List<string> numbersStr = new List<string>();
            int StartPos = 0;
            StringBuilder SB = new StringBuilder();
            for(int x = 0; x < testString.Length; x++)
            {
                if(testString[x] == '"')
                {
                    inQuote = !inQuote;
                    continue;
                }
                if(testString[x] == ',' && !inQuote )
                {
                    numbersStr.Add(SB.ToString());
                    SB.Clear();
                    continue; 
                }
                if(char.IsDigit(testString[x]) || testString[x] == '.')
                {
                    SB.Append(testString[x]);
                }
            }
            if(SB.Length != 0)
            {
                numbersStr.Add(SB.ToString());
            }
            var nums = numbersStr.Select(x => double.Parse(x));
            foreach(var num in nums)
            {
                Console.WriteLine(num);
            }
            Console.ReadLine();
        }
    }
