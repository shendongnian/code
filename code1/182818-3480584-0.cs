    using System;
    
    public static class Extensions
    {
        public static double GetDouble(this Outer.ErrorCode code)
        {
            return (double)(int)code;
        }
    }
    
    public class Outer
    {
        public enum ErrorCode
        {
            Error1, Error2, Error3
        }
    }
    
    public class Test
    {
        public static void Main()
        {
            Outer.ErrorCode code = Outer.ErrorCode.Error1;
            Console.WriteLine(code.GetDouble());
        }
    }
