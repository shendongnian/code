      public class RuleCondition
      {
        public RuleCondition(string field,
                         Operator @operator,
                         RightValueExpression rightValueExpression)
        {
          ValueExpression = rightValueExpression;
          Field = field;
          Operator = @operator;
        }
    
        public RightValueExpression ValueExpression { get; set; }
        public string Field { get; }
        public Operator Operator { get; }
      }
