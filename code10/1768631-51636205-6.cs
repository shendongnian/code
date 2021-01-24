    public override ASTExpr Visit(SumExpr e){
        return new SumExpr(
          Visit(e.A),     // You are passing ASTExpr where as SumExpr is expected
          Visit(e.B));    // You are passing ASTExpr where as SumExpr is expected
      }
