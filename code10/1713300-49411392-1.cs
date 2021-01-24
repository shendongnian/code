    class Subcriber
    {
        TechToday tt = new TechToday();
        SoftwareRevolution sr = new SoftwareRevolution();
    
        public void Subcribe(TechToday s)
        {
            new ConsoleObserver(s);
        }
    
        public void Subcribe(SoftwareRevolution s)
        {               
            new ConsoleOutput(s);
        }
    
    }
