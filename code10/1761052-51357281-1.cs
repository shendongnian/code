        static void  Main()
        {
            Console.WriteLine("Starting");
            //Save project
            Console.WriteLine("Project saved");
            Task task = new Task(new Action(LogDiff));
            task.Start();
            Console.ReadLine();
        }
    
        public void LogDiff()
        {
            var results = GetDiff("Processing Diff");
            Console.WriteLine(results);
        }
