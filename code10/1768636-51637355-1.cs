    public override ASTExpr Visit(ASTExpr e)
    {
        switch (e)
        {
            case SumExpr sum:
               return Visit(sum); 
            case ProductExpr product:
               return Visit(product);
            case ConstantExpr constant:
               return Visit(constant);
            case SymbolExpr symbol:
               return Visit(symbol);
            default:
               throw new ArgumentException();
        }
    }
