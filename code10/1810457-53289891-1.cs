        static void Main(string[] args)
        {
            var possibilities = new[]
            {
                new[] {0, 1, 1, 1, 1, 1, 1, 1},
                new[] {1, 1, 1, 1, 1, 1, 1, 0}
            };
            //[ 0, 1, 1, 1, 1, 1, 1, 0 ]
            var result = possibilities.Aggregate((f, s) => f.Zip(s, (fi, si) => fi & si).ToArray());
            var possibilities2 = new[]
            {
                new[] {1, 1, 0, 1, 1, 0, 0, 0},
                new[] {1, 1, 0, 1, 1, 0, 0, 1},
                new[] {0, 1, 1, 0, 1, 1, 0, 1}
            };
            //[ 0, 1, 0, 0, 1, 0, 1, 0 ]
            var result2 = possibilities2.Aggregate((f, s) => f.Zip(s, (fi, si) => fi & si).ToArray());
            Console.ReadLine();
        }
