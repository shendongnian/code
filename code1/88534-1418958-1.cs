        public void activator()
        {
            var stopwatch = new Stopwatch();
            const int times = 10000000;
    
            stopwatch.Start();
            for (int i = 0; i < times; i++)
            {
                var v = Activator.CreateInstance(typeof (C));
            }
            stopwatch.Stop();
    
            Console.WriteLine(stopwatch.ElapsedMilliseconds + "ms with activator");
            
            var del = CreateConstructorDelegate(typeof(C).GetConstructor(new Type[0]));
    
            stopwatch = new Stopwatch();
            stopwatch.Start();
    
            var args = new object[0];
    
            for (int i = 0; i < times; i++)
            {
                var v = del(args);
            }
    
            stopwatch.Stop();
            
            Console.WriteLine(stopwatch.ElapsedMilliseconds + "ms with expression");
        }
