    public class Calculator
    {
        public void Calculate(int value)
        {
            //Do Something
        }
        public void Calculate(decimal value)
        {
            //Do Something
        }
        public void Calculate(double value)
        {
            //Do Something
        }
    }
    
    static void Main(string[] args)
    {
        int i = 0;
        Calculator calculator = new Calculator();
        calculator.Calculate(i);
    }
