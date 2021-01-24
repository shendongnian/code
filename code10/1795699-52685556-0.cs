    using System;
    public class Program
    {
        public static void Main()
        {
            var id = (int)Settings.th;
            Settings.action = () => id = Settings.th;
            Settings.th = 123;
            Console.WriteLine(id);
    		
            Settings.th = 234;
            Console.WriteLine(id);
        }
    	
        public static class Settings
        {
            private static int _th;
            public static int th
            {
                get{return _th;}
                set{
                    _th = value;
                    action();}
            }
    		
            public static Action action;
        }
    }
