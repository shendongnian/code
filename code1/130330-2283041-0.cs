    class EmptyProcessor {
        public override event EventHandler OnProcess { 
            add { throw new Exception(" :( "); }
            remove { }
        }
    }
