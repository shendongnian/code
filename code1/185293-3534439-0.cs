    public class Ex
    {
        private readonly Expression expr;
    
        public Ex(Expression expr)
        {
            this.expr= expr;
        }
        public Expression Expression
        {
            get { return this.expr; }
        }
    
        public static Ex operator +(Ex left, Ex right)
        {
            return new Ex(Expression.Add(left.expr, right.expr));
                                                ↑           ↑
        }
        // etc.
    }
