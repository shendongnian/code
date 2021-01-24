    public class NotADimensionContainer : LineContainer
    {
      // etc        
    }
        
    internal class Program
    {
        private static void Main()
        {
            var dimensionContainer = new DimensionContainer();
            var canGroup = dimensionContainer.CanBeGroupedWith(new NotADimensionContainer());
        }
    }
