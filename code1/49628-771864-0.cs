    class Rule {
    public String FieldName { get; set; }
    public MatchType Match { get; set; }
    public Object Value { get; set; }
    )
    
    enum MatchType {
    Equal = 1,
    NotEqual = 2,
    GreaterThan = 4,
    LessThan = 8,
    Like = 16
    }
