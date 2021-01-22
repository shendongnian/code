    using System;
    using System.Runtime.CompilerServices;
    
    namespace LogFileLine
    {
        public static class F
        {
            // This method returns the callers filename and line number
            public static string L([CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
            {
                // Remove path leaving only filename
                while (file.IndexOf("\\") >= 0)
                    file = file.Substring(file.IndexOf("\\")+1);
    
                return String.Format("{0} {1}:", file, line); 
            }
        }
        
        public static class Log
        {
            // Log a formatted message. Filename and line number of location of call
            // to Msg method is automatically appended to start of formatted message.
            // Must be called with this syntax:
            // Log.Msg(F.L(), "Format using {0} {1} etc", ...);
            public static void Msg(string fileLine, string format, params object[] parms)
            {
                string message = String.Format(format, parms);
                Console.WriteLine("{0} {1}", fileLine, message);
            }
        }
        
        class Program
        {
            static void Main(string[] args)
            {
                int six = 6;
                string nine = "nine";
                string dog = "dog";
                string cat = "cats";
    
                Log.Msg(F.L(), "The {0} chased the {1} {2}", dog, 5, cat);
    
                Log.Msg(F.L(), "Message with no parameters");
    
                Log.Msg(F.L(), "Message with 8 parameters {0} {1} {2} {3} {4} {5} {6} {7}",
                    1, 2, 3, "four", 5, 6, 7, 8.0);
    
                Log.Msg(F.L(), "This is a message with params {0} and {1}", six, nine);
            }
        }
    }
