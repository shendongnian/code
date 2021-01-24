    class Subcriber
    {
        public void Subcribe(TechToday s)
        {
            new ConsoleObserver(s);
        }
    
        public void Subcribe(SoftwareRevolution s)
        {               
            new ConsoleOutput(s);
        }
    
    }
