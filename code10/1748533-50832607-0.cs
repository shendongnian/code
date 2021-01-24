    class Program
    {
        static void Main(string[] args)
        {
            //warmup types
            var vm = new TestViewModel();
            Console.ReadLine(); //Snapshot #1
            for (int i = 0; i < 1000; i++)
                Model();
            GC.Collect();
            Console.ReadLine();  //Snapshot #2
        }
        private static void Model()
        {
            using (var vm = new TestViewModel())
            {                
            }
        }
    }
