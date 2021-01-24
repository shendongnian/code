     public override ASTExpr Visit(ProductExpr e){
        return new SumExpr(
          new ProductExpr(Visit(e.A), e.B),
          new ProductExpr(Visit(e.B), e.A));
      }
