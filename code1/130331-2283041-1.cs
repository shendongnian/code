    class EmptyProcessor : IProcessor {
        [Obsolete("EmptyProcessor.OnProcess should not be directly accessed", true)]
        public event EventHandler OnProcess { 
            add { throw new NotImplementedException(" :( "); }
            remove { }
        }
    }
