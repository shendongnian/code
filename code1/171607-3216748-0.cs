    class Program
    {
        class MyClass
        {
            public int ID;
            public int first;
            public int second;
        }
        static void Main(string[] args)
        {
            // create a sequence containing example data
            List<MyClass> sequence = new List<MyClass>();
            sequence.AddRange(new MyClass[] {
                new MyClass { ID = 1, first = 0, second = 10 },
                new MyClass { ID = 2, first = 1, second = 11 },
                new MyClass { ID = 3, first = 2, second = 12 },
                new MyClass { ID = 4, first = 0, second = 10 },
                new MyClass { ID = 5, first = 1, second = 20 },
                new MyClass { ID = 6, first = 2, second = 30 },
                new MyClass { ID = 7, first = 0, second = 0 },
                new MyClass { ID = 8, first = 1, second = 11 },
                new MyClass { ID = 9, first = 2, second = 12 },
            });
            var matches = from x in sequence
                          join y in sequence // join sequence to itself
                          on x.first equals y.first // based on the first field
                          where
                            !object.ReferenceEquals(x, y) // avoid matching an item to itself
                            && x.second != y.second // find cases where the second field is not equal
                          select new { X = x, Y = y }; // return a "tuple" containing the identified items
            foreach (var match in matches)
            {
                Console.WriteLine("Found first:{0}, x.second:{1}, y.second:{2}, x.ID:{3}, y.ID:{4}", match.X.first, match.X.second, match.Y.second, match.X.ID, match.Y.ID);
            }
        }
    }
