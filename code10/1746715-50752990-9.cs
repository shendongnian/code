    using System;
    using System.Collections.Generic;
    
    public class Program
    {
        static List<Action> action1 = new List<Action>();
        static List<Action> actionHandler;
        public static void Main()
        {
            WaitForActionProcess(action1);
        }
    
        public static void WaitForActionProcess(List<Action> action)
        {
            action.Add(Both);
    
            // assignment passes a reference to the List
            actionHandler = action;
    
            action.Add(OnlyAction1);
            actionHandler.Add(OnlyActionHandler);
    
            // now things work nicely
            foreach(var a in action) a();
            foreach(var a in actionHandler) a();
        }
    
        public static void Both()=> Console.WriteLine("Both");
        public static void OnlyAction1() => Console.WriteLine("OnlyAction1");
        public static void OnlyActionHandler() => Console.WriteLine("OnlyActionHandler");
    }
