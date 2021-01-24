    class ExpressionIntVisitor : IExpressionVisitor
    {
        Stack<int> stack = new Stack<int>();
        public int GetRetVal()
        {
            return stack.Peek();
        }
        public void Visit(LiteralExpression exp)
        {
            stack.Push(exp.Value);
        }
        public void Visit(PlusExpression exp)
        {
            exp.Op0.Accept(this);
            exp.Op1.Accept(this);
            int b = stack.Pop();
            int a = stack.Pop();
            stack.Push(checked(a + b));
        }
