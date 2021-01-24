    class Program
    {
        // volatile might not be necessarily or desired here;
        // I don't remember in all honestly why I had it there, try with or without
        static volatile object _locker = new object();
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(o => TwainWork());
            Console.ReadLine();
        }
        void TwainWork()
        {
            bool lockWasTaken = false;
            try
            {
                if (Monitor.TryEnter(_locker))
                {
                    lockWasTaken = true;
                    Scan();
                }
                else 
                {
                    return;
                }
            }
            finally
            {
                if (lockWasTaken)
                {
                    Monitor.Exit(_locker);
                }
            }
        }
        void Scan()
        {
            var identity = TWIdentity.CreateFromAssembly(DataGroups.Image, Assembly.GetEntryAssembly());
            var twain = new TwainSession(identity);
            twain.Open();
            twain.DataTransferred += (s, e) =>
            {
                var stream = e.GetNativeImageStream();
                var image = Image.FromStream(stream);
                // Do things with the image...
            };
            var source = twain.First();
            Console.WriteLine($"Scanning from {source.Name}...");
            var openCode = source.Open();
            Console.WriteLine($"Open: {openCode}");
            source.Enable(SourceEnableMode.NoUI, false, IntPtr.Zero);
        }
    }
