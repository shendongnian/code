    using System;
    
    class Program
    {
        static void ActionMethod(Action action) {}
        static void IntMethod(int x) {}
            
        static string GetString() { return ""; }
        
        static void Main(string[] args)
        {
            IntMethod(GetString);
            ActionMethod(GetString);
        }
    }
