    public interface ISum
    {
        int Sum(int x, int y);
    }
    public class SumImpl : ISum
    {
        public int Sum(int x, int y)
        {
            return x + y;
        }
    }
    public class Multiply
    {        
        public int Mul(int x, int y)
        {
            return x * y;
        }
    }
    // Generate a type that does multiply and sum
    Type newType = MixinGenerator.CreateMixin(typeof(Multiply), typeof(ISum));
    object instance = Activator.CreateInstance(newType, new object[] { new SumImpl() });
    int res = ((Multiply)instance).Mul(2, 4);
    Console.WriteLine(res);
    res = ((ISum)instance).Sum(1, 4);
    Console.WriteLine(res);
