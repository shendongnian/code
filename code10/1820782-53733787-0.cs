    sealed class PlusExpression : BinaryExpression
    {
        public override object Accept(ExpressionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
