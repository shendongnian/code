    class StackInfo
    {
        protected Stack<SomeClass> _stack;
        public Expression Push(SomeClass item)
        {
            MethodInfo mi = _stack.GetType().GetMethod("Push");
            return Expression.Call(Expression.Constant(_stack), mi, Expression.Constant(item));
        }
    }
