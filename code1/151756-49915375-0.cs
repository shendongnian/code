            var shouldntBeInt = 3.1415;
            var iDontWantThisToBeInt = 3.000f;
            Console.WriteLine(int.TryParse(shouldBeInt.ToString(), out int parser)); // true
            Console.WriteLine(int.TryParse(shouldntBeInt.ToString(), out parser)); // false
            Console.WriteLine(int.TryParse(iDontWantThisToBeInt.ToString(), out parser)); // true, even if I don't want this to be int
            Console.WriteLine(int.TryParse("3.1415", out  parser)); // false
            Console.WriteLine(int.TryParse("3.0000", out parser)); // false
            Console.WriteLine(int.TryParse("3", out parser)); // true
            Console.ReadKey();
