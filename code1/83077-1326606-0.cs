            List<int> ints = new List<int> { 1, 2, 3 };
            var ro = ints.AsReadOnly();
            Console.WriteLine(ro.Count); // 3
            ints.Add(4);
            Console.WriteLine(ro.Count); // 4
