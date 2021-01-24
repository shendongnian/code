        public TimeCapture
        {
             public TimeCapture() => Start = DateTime.Now;
    
             public Start { get; }
        
             public TimeSpan Duration => DateTime.Now.Subtract(Start).Value.TotalSeconds;
        }
    
