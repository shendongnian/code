     class Program
    {
        private static void FindLetter(string[] alphabet, string[] yourMissingLetter)
        {
            for (var i = 0; i < yourMissingLetter.Length; i++)
            {
                Console.WriteLine(alphabet[i] + "=" + yourMissingLetter[i]);
            }
        }
        static void Main(string[] args)
        {
            string[] alphabet = { "A", "B", "C", "D" };
            // let's say your array is missing B
            string[] yourMissingLetterArray = { "A", "C", "D" };
            FindLetter(alphabet, yourMissingLetterArray);
        }
    }
