    public override ASTExpr Visit(SumExpr e){
        return new SumExpr(
          Visit(e.A),     // It should be e not e.A
          Visit(e.B));    // It should be e not e.B
      }
    public override ASTExpr Visit(SumExpr e){
            return new SumExpr(
              Visit(e),     // It should be e not e.A
              Visit(e));    // It should be e not e.B
          }
