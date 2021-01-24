    static void Main(string[] args)
    {
      var i = 9;
      Expression<Func<Product, bool>> where = x => x.Id == i;
      new ExpressionWriterVisitor(Console.Out).Visit(where);
    }
