    public class MyEntity
    {
        public string Code
        {
           get;
           private set;
        }
    
        public bool IsValidFor( ... )
        {
            IRule rule = RuleRegistry.GetRuleFor(this);
    
            if( rule.IsValid() ) ...
        }
    
    }
    
    [RuleAttrib("100")]
    public class MyRule : IRule
    {
        public bool IsValid()
        {
        }
    }
