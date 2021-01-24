        static void Main(string[] args)
        {
            Console.WriteLine(CountChar("asdasdasdasd",'a'));
            Console.WriteLine(CountChar("asdasdasdasdbb", 'b'));
        }
        public static int CountChar(string text, char character)
        {
            if(text.Length==1)
            {
                if (text[0] == character)
                    return 1;
                else
                    return 0;
            }
            else
            {
                return (text[0] == character ? 1 : 0) + CountChar(text.Substring(1), character);
            }
        }
