    public class JNumber : INumber
    {
        decimal num = 0;
    
        public void add1000()
        {
            num = 10000000000;
        }
    
        public void SetValue(decimal d)
        {
        }
    
        decimal GetValue()
        {
            return num;
        }
    }
