    public abstract class MustImplement<T> where T: IValue
    {
    	public abstract IEnumerable<T> GetValues(int number);
    }
    
    public class SpecificClass : MustImplement<SpecificValue>
    {
    	public override IEnumerable<SpecificValue> GetValues(int number)
    	{
    		var rv = new List<SpecificValue>();
    		rv.Add(new SpecificValue()
    		{Val = number + "Test"});
    		return rv;
    	}
    }
