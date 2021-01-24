        private static readonly object locked = new object();
        static void ThreadedFunc(object i)
        {
            // Only one thread will execute this code
            lock (locked)
            {                
                //  When you exit the Using block, the `VBScriptEngine` is going to be disposed
                using (VBScriptEngine vbsengine = new VBScriptEngine())
                {
                    Console.WriteLine(i + ": " + vbsengine.Evaluate("1+1"));                    
                }
            }
        } 
