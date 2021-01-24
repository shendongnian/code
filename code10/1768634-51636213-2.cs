    public override ASTExpr Visit(ASTExpr e)
        {
            if (e as SumExpr != null)
                return Visit(e as SumExpr);
    
            if (e as ProductExpr != null)
                return Visit(e as ProductExpr);
    
            if (e as ConstantExpr != null)
                return Visit(e as ConstantExpr);
    
            if (e as SymbolExpr != null)
                return Visit(e as SymbolExpr);
    
            throw new ArgumentException();
        }
