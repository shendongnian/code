     class Program
    {
        private static void FindLetter(string[] alphabet, string[] yourMissingLetter)
        {
            for (var i = 0; i < yourMissingLetter.Length; i++)
            {
                var isit = alphabet[i] == yourMissingLetter[i];
                Console.WriteLine("alphabet[{0}] = {1}", alphabet[i], isit);
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
