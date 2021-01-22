    using System;
    
    class Test
    {
        static int value;
    
        static void ShowValue(string description)
        {
            Console.WriteLine(description + value);
        }
    
        static void Main()
        {
            Console.WriteLine("Return value test...");
            value = 5;
            value = ReturnValue();
            ShowValue("Value after ReturnValue(): ");
    
            value = 5;
            Console.WriteLine("Out parameter test...");
            OutParameter(out value);
            ShowValue("Value after OutParameter(): ");
        }
    
        static int ReturnValue()
        {
            ShowValue("ReturnValue (pre): ");
            int tmp = 10;
            ShowValue("ReturnValue (post): ");
            return tmp;
        }
    
        static void OutParameter(out int tmp)
        {
            ShowValue("OutParameter (pre): ");
            tmp = 10;
            ShowValue("OutParameter (post): ");
        }
    }
