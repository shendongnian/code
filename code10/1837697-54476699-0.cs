        public static void a()
        {
            Console.WriteLine("always show");
            DebugLog();
        }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        static void DebugLog()
        {
            Console.WriteLine("debug show");
        }
