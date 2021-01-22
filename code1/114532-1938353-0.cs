    public interface IExchangeClass
    {
        int Subtract(int firstNum, int secNum);
    }
    
    public class SingaporeClass : IExchangeClass
    {
        public int Subtract(int firstNum, int secNum)
        {
            return firstNum - secNum;
        }
    }
    
    public class NurseryClass : IExchangeClass
    {
        public int Subtract(int firstNum, int secNum)
        {
            return firstNum - secNum;
        }
    }
    
    public class PrimaryClass : IExchangeClass
    {
        public int Subtract(int firstNum, int secNum)
        {
            return firstNum - secNum;
        }
    }
    
    public class SecondaryClass : IExchangeClass
    {
        public int Subtract(int firstNum, int secNum)
        {
            return firstNum - secNum;
        }
    }
    
    public class ExchangeHelper
    {
        public int Subtract<T>(int firstNum, int secNum) where T : IExchangeClass, new ()
        {
            T exchange = new T();
    
            return exchange.Subtract(firstNum, secNum);
        }
    }
