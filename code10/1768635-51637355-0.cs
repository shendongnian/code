    public override ASTExpr Visit(ASTExpr e)
    {
        if (e is SumExpr sum)
            return Visit(sum);
        if (e is ProductExpr product)
            return Visit(product);
        if (e is ConstantExpr constant)
            return Visit(constant);
        if (e is SymbolExpr symbol)
            return Visit(symbol);
        throw new ArgumentException();
    }
