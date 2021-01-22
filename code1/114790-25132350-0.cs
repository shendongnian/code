        void runThread()		
        {
            ThreadContext ctx = new ThreadContext();
            ctx.Value = 8;
            Thread t = new Thread(new ParameterizedThreadStart(MyThread));
            //t.SetApartmentState(ApartmentState.STA); // required for some purposes
            t.Start(ctx);
		    // ...
            t.Join();
            Console.WriteLine(ctx.Result);
        }
        private static void MyThread(object threadParam)
        {
            ThreadContext context = (ThreadContext)threadParam;
            context.Result = context.Value * 4; // compute result
        }
        class ThreadContext
        {
            public int Value { get; set; }
            public int Result { get; set; }
        }
