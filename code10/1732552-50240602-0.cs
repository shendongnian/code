        static void Main(string[] args)
        {
            var vbengines = new VBScriptEngine[Environment.ProcessorCount];
            var checkPoint = new ManualResetEventSlim();
            for (var index = 0; index < vbengines.Length; ++index)
            {
                var thread = new Thread(indexArg =>
                {
                    using (var engine = new VBScriptEngine())
                    {
                        vbengines[(int)indexArg] = engine;
                        checkPoint.Set();
                        Dispatcher.Run();
                    }
                });
                thread.Start(index);
                checkPoint.Wait();
                checkPoint.Reset();
            }
            Parallel.ForEach(Enumerable.Range(0, 4000), item => {
                var engine = vbengines[item % vbengines.Length];
                
                engine.Dispatcher.Invoke(() => {
                    ThreadedFunc(new myobj() { vbengine = engine, index = item });
                });
            });
            Array.ForEach(vbengines, engine => engine.Dispatcher.InvokeShutdown());
            Console.ReadKey();            
        }
        static void ThreadedFunc(object obj)
        {            
            Console.WriteLine(((myobj)obj).index.ToString() + ": " + ((myobj)obj).vbengine.Evaluate("1+1").ToString());
        }
        class myobj
        {
            public VBScriptEngine vbengine { get; set; }
            public int index { get; set; }
        }
