    using System;
    
     public static class ConsoleEx {
            public static bool IsConsoleSizeZero {
                get {
					try {
						return (0 == (Console.WindowHeight + Console.WindowWidth));
					}
					catch (Exception exc){
						return true;
					}
				}
            }
			public static bool IsOutputRedirected {
				get { return IsConsoleSizeZero && !Console.KeyAvailable; }
			}
			public static bool IsInputRedirected {
				get { return IsConsoleSizeZero && Console.KeyAvailable; }
			}
    }
