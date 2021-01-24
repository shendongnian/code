    class Subcriber
    {
        public void Subcribe(Object s)
        {
            if(s is TechToday)
                new ConsoleObserver(s);
            else                
                new ConsoleOutput(s);
    
        }
    }
