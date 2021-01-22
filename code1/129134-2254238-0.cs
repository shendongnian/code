    using System;
    
    class Test
    {
        public class DerivedEventArgs : EventArgs { }
    
        public EventHandler<DerivedEventArgs> SpecialistEvent;
        
        static void Main()
        {
            Test t = new Test();
            t.SpecialistEvent += GeneralHandler;
        }
        
        static void GeneralHandler(object sender, EventArgs e)
        {
        }
    }
