    condition.Evaluate(accumulator);
    class Condition
    {
        public int Evaluate(int argument)
        {
            return Operation.Evaluate(Expression(0), argument);
        }
    }
