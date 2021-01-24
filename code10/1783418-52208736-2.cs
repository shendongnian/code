    public static class Calculator
    {
        public enum Action { Add, Subtract, Multiply, Power }
        public static double Add(double x, double y)
        {
            return x + y;
        }
        public static double Subtract(double x, double y)
        {
            return x - y;
        }
        public static double Multiply(double x, double y)
        {
            return x * y;
        }
        public static double Power(double x, double y)
        {
            return Math.Pow(x, y);
        }
        public static void PrintCalculation(Action action, double x , double y)
        {
            switch (action)
            {
                case Action.Add:
                    Console.WriteLine("The sum of {0} and {1} is: {2}", 
                        x, y, Add(x, y));
                    break;
                case Action.Subtract:
                    Console.WriteLine("The difference between {0} and {1} is: {2}", 
                        x, y, Subtract(x, y));
                    break;
                case Action.Multiply:
                    Console.WriteLine("The product of {0} and {1} is: {2}", 
                        x, y, Multiply(x, y));
                    break;
                case Action.Power:
                    Console.WriteLine("{0} raised to the power of {1} is: {2}", 
                        x, y, Power(x, y));
                    break;
            }
        }
    }
