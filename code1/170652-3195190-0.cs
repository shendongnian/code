    public class SOVisitor_3194678 : ExpressionVisitor
    {
      private List<ConstantExpression> _dodgyConstants =
        new List<ConstantExpression>();
      public List<ConstantExpression> DodgyConstants
      {
        get
        {
          return _dodgyConstants;
        }
      }
      public SOVisitor_3194678(Expression toVisit)
      {
        Visit(toVisit);
      }
      protected override Expression VisitConstant(ConstantExpression c)
      {
        //technically speaking this test should be a lot deeper, such as
        //checking the declaring assembly is not the same as the one
        //that the code that wants to generate the expression (in which case
        //being IsVisible==false is fine); and that the class is not nested 
        //inside another type and marked private.  However, you won't be
        //using this code very much after fixing this bug!
        if (c.Type.IsVisible == false ||
          c.Type.GetConstructors(System.Reflection.BindingFlags.Instance
          | System.Reflection.BindingFlags.NonPublic).Any())
        {
          _dodgyConstants.Add(c);
        }
        return base.VisitConstant(c);
      }
    }
    [TestMethod]
    public void ShouldFindThreeOutOfFour()
    {
      Expression arrayExpr = Expression.NewArrayInit
      (
        typeof(object),
        Expression.Constant(new PrivateClass(), typeof(PrivateClass)),
        Expression.Constant(new PublicClass(), typeof(PublicClass)),
        Expression.Constant(null, typeof(PublicClassWithPrivateConstructor)),
        Expression.Constant(new PublicClassWithOneInternalConstructor(), 
          typeof(PublicClassWithOneInternalConstructor))
      );
      SOVisitor_3194678 visitor = new SOVisitor_3194678(arrayExpr);
      Assert.AreEqual(3, visitor.DodgyConstants.Count);
    }
