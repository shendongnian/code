    class RuleEngine 
    {
      public RuleMatch[] RuleMatches { get; set; }
      public void RunEngine(inputdata...) 
      {  
        // do processing in here
      }
    }
    class RuleMatch 
    {
      public Rule[] Rules { get; set; }
      public Object ValueIfMatched { get; set; }
    }
    
    class Rule 
    {
      public String FieldName { get; set; }
      public MatchType Match { get; set; }
      public Object Value { get; set; }
    )
    
    enum MatchType 
    {
      Equal = 1,
      NotEqual = 2,
      GreaterThan = 4,
      LessThan = 8,
      Like = 16
    }
