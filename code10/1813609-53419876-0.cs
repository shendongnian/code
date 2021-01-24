        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var inputs = input.Split(' ');
            var sentence = string.Join(" ", inputs.Select(ConvertWord));
            Console.Write(sentence);
            Console.Read();
        }
        internal static string ConvertWord(string input)
        {
            const string che = "che";
            var vowels = new List<string>
            {
                "a","A", "e", "E", "i", "I", "o", "O", "u", "U"
            };
            var firstChar = input.First();
            var startsWithVowel = vowels.SingleOrDefault(a => a.Equals(firstChar));
            string rule2String, output;
            if (string.IsNullOrEmpty(startsWithVowel))
            {
                output = input + che;
            }
            else
            {
                output = input.Substring(1) + startsWithVowel + che;
            }
            rule2String = IsLengthEven(input)
                ? output + "e"
                : output
            ;
            return rule2String;
        }
        internal static bool IsLengthEven(string input)
        {
            return input.Length % 2 == 0;
        }
