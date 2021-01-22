    public abstract class BaseClass
    {
        public static BaseClass Create(int parameter)
        {
            if (parameter == 1)
            {
                return new Class1();
            }
            else
            {
                return new Class2();
            }
        }
    }
    
    internal class Class1 : BaseClass
    {
        ...
    }
    
    internal class Class2 : BaseClass
    {
        ...
    }
