            static void Main(string[] args) {
            var Init = // Some path
            var Data = Init.Traverse(Dir => Directory.GetDirectories(Dir, "*", SearchOption.TopDirectoryOnly));
            foreach (var Dir in Data)
                Console.WriteLine(Dir);
            Console.ReadKey();
        }
