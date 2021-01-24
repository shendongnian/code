      public class RuleCondition
      {
        public RuleCondition(string field,
                         Operator @operator,
                         RightValueExpression rightValueExpression)
        {
          RightValueExpression = rightValueExpression;
          Field = field;
          Operator = @operator;
        }
    
        public RightValueExpression RightValueExpression { get; }
        public string Field { get; }
        public Operator Operator { get; }
      }
