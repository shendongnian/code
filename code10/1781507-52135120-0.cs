    using System;
    namespace ConsoleApp
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(SplitOnChar("124,45415,1212,4578,233,968,6865,32545,4545",',',4));
            Console.ReadKey();
        }
        private static string SplitOnChar(string input, char theChar, int number)
        {
            string result = "";
            int seen = 0;
            int lastSplitIndex = 0;
            for(int i = 0; i< input.Length;i++)
            {
                char c = input[i];
                if (c.Equals(theChar))
                {
                    seen++;
                    if (seen == number)
                    {
                        result += input.Substring(lastSplitIndex + 1, i - lastSplitIndex -1);
                        result += Environment.NewLine;
                        lastSplitIndex = i;
                        seen = 0;
                    }
                }
            }
            result += input.Substring(lastSplitIndex + 1);
            return result;
        }
    }
    }
