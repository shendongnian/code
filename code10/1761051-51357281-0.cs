        static void  Main()
        {
            Console.WriteLine("Starting");
            //Save project
            Console.WriteLine("Project saved");
            Task.Run(() => LogDiff());
            Console.ReadLine();
        }
    
        public void LogDiff()
        {
            var results = GetDiff("Processing Diff");
            Console.WriteLine(results);
        }
