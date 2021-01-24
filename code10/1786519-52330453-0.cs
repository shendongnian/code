    public class Multiplier : ICalculator
    {
        public decimal Calculate()
        {
            return _x * _y; // _x and _y are fields
        }
    }
    
    public class Divider : ICalculator
    {
        public decimal Calculate()
        {
            return _x / _y;
        }
    }
