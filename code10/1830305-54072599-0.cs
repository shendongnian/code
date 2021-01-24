        private delegate bool CustomPredicate (string t);
        static void Main(string[] args)
        {
            List<string> _ListOfPlayers = new List<string>()
            {
                "James Anderson",
                "Broad",
                "foo"
            };
            // Method 1. Predicate and Anonymous function.
            CustomPredicate _Predicate = delegate (string someString) { return    someString.Length == 3; };
            string result = _ListOfPlayers.FirstOrDefault(x => _Predicate(x));
            Console.WriteLine("Result : {0}", result);
            Console.ReadLine();
        }
