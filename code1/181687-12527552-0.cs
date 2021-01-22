    using System;
    
     public static class ConsoleEx {
        private static bool isConsoleSizeZero { 
            get{  return 0 == (Console.WindowHeight + Console.WindowWidth); }
        }
        public static bool IsOutputRedirected {
            get { return isConsoleSizeZero && !Console.KeyAvailable; }
        }
        public static bool IsInputRedirected {
            get { return isConsoleSizeZero && Console.KeyAvailable; }
        }
    
    }
