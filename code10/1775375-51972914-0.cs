    public interface IReplaceRule : IRule { object ReplaceValue { get; set; } }
    
    public interface IReplaceRule<T> : IReplaceRule { new T ReplaceValue { get; set; } }
    
    public class CachedRules<T> where T : IReplaceRule
    {
    	public IDictionary<string, T> RuleList { get; private set; } = new Dictionary<string, T>();
    
        //The key ingredient for a nice experience instead of just doing this in the method
    	public static implicit operator CachedRules<IReplaceRule>(CachedRules<T> rules)
    		=> new CachedRules<IReplaceRule> { RuleList = rules.RuleList.ToDictionary(x => x.Key, x => x.Value as IReplaceRule) };
    }
    
    public class SingleRowRule : IReplaceRule<string>
    {
    	public string ReplaceValue { get; set; }
    	object IReplaceRule.ReplaceValue { get => ReplaceValue; set => ReplaceValue = value as string; }
    }
    
    public class RulesStorage
    {
    	private CachedRules<SingleRowRule> singleRowRules = new CachedRules<UserQuery.SingleRowRule>();
    
    	//FIXME: just for testing purposes
    	public RulesStorage() => singleRowRules.RuleList.Add("Hello", new SingleRowRule { ReplaceValue = "World" });
    
    	// Here I need to return a list of ChachedRule, but just ofr testing I tried to return only one
    	public CachedRules<IReplaceRule> GetCachedReplaceRules() => singleRowRules;
    }
