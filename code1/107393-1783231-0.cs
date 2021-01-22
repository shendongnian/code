    public interface ICalculator
    {
      public int Add(int a, int b)
    }
    public class Calculator : ICalculator
    {
      public int Add(int a, int b) { return a + b; }
    }
    public class TestCalculatorInterface
    {
       public abstract SomeMath GetObjectToTest();
    
       [Test]
       public void TestAdd()
       {
           var someMath = GetObjectToTest();
           ...
       }
    }    
    [TestFixture]
    public class TestCalculator: TestCalculatorInterface
    {
       public virtual Calculator GetObjectToTest() { return new Calculator(); }
    }
