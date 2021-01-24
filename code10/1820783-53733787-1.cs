    class ExpressionVisitor
    {
            public bool d;
    
            public ExpressionVisitor(bool d) { this.d = d; }
    
            public object Visit(LiteralExpression exp)
            {
                if (d)
                    return (double)exp.Value;
                else
                    return (int)exp.Value;
            }
    
            public object Visit(PlusExpression exp)
            {
                if (d)
                    return checked((double)exp.Op0.Accept(this) + (double)exp.Op1.Accept(this));
                else
                    return checked((int)exp.Op0.Accept(this) + (int)exp.Op1.Accept(this));
            }
    }
