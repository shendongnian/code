    class Subcriber
    {
        public void Subcribe(Object s)
        {
            var tt = s as TechToday; 
            if(tt!=null)
               // unlike above 
               // value passed to ConsoleObserver is TechToday
               // casted already
    
                new ConsoleObserver(tt); 
            else                
                new ConsoleOutput(s);
        }
    }
