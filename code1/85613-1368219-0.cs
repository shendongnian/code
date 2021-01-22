    public class Condition<TValue, TOperator> 
    {
        public TValue Value { get; private set; }
        public TOperator Operator { get; private set; }
        private Condition(TValue val, TOperator op)
        {
            Value = val;
            Operator = op;
        }
    }
