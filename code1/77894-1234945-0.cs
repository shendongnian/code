    public class MultiplexByThreadConsole : IDisposable
    {
        private readonly TextWriter originalOut;
        private readonly TextWriter myOut = new IndividualMultiplex();
        public MultiplexByThreadConsole()
        {
            this.originalOut = Console.Out;
            Console.SetOut(this.myOut);
        } 
        
        public void Dispose()
        {
            Console.SetOut(this.originalOut);            
        }
    
        private class IndividualMultiplex : TextWriter
        {
            [ThreadStatic]
            private readonly TextWriter actual;
            
            // override all the required functions and any 
            // others you want to wrap 
            public override void Write(char c)
            {
                 if (actual == null)
                 {
                     actual = MakeWhateverYouReallyWantToOutputTo();
                 }
                 actual.Write(c);
            }
        }
    }
