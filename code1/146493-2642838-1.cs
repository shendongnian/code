    public class Filter_Base
    {
    	protected string _filter;
    
    	public Filter_Base(string filter)
    	{
    		_filter = filter;
    	}
    
    	[FilterMethod("new")]
    	public virtual List<string> new_issues()
    	{
    		return new List<string>();
    	}
    }
    [FilterType("Worker")]
    public class Filter_Worker : Filter_Base
    {
    	public Filter_Worker(string filter) :
    		base(filter)
    	{ }
    
    	public override List<string> new_issues()
    	{
    		return new List<string>();
    	}
    } 
