        public static async Task TaskMethod()
        {
            Debug.WriteLine("Start Waiting");
            Task t = Task.Run(() => DoSomething() );
        }
        private static void DoSomething()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Wake up !");
        }
